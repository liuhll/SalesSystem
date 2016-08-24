using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Logging;
using Abp.Runtime.Session;
using Jeuci.SalesSystem.Domain.Sales.Models;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common;
using Jeuci.SalesSystem.Entities.Common.Enums;
using Jeuci.SalesSystem.Helper;
using Jeuci.SalesSystem.Domain.Sales.Policy;

namespace Jeuci.SalesSystem.Domain.Sales.Impl
{
    public class SalesSoftwareProcessor : ISalesSoftwareProcessor
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<UserServiceAuthInfo> _userServiceAuthRepository;
        private readonly IRepository<UserServiceSubscriptionInfo, string> _userServiceSubscriptionRepository;
        private readonly IRepository<ServicePrice> _servicePriceRepository;

        public SalesSoftwareProcessor(
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<UserServiceAuthInfo> userServiceAuthRepository,
            IRepository<UserServiceSubscriptionInfo, string> userServiceSubscriptionRepository,
            IRepository<ServicePrice> servicePriceRepository)
        {
            _userServiceAuthRepository = userServiceAuthRepository;
            _userServiceSubscriptionRepository = userServiceSubscriptionRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _servicePriceRepository = servicePriceRepository;
        }

        public async Task<PurchaseTypeCode> IsPurchaseHigherVersion(UserInfo user, int servicePriceId)
        {
            var userServiceAuthInfos = await _userServiceAuthRepository.GetAllListAsync(p => p.UId == user.Id
            && (p.AuthExpiration == null || p.AuthExpiration.Value >= DateTime.Now));

            var servicePriceInfo = await _servicePriceRepository.GetAsync(servicePriceId);

            if (userServiceAuthInfos == null || userServiceAuthInfos.Count <= 0)
            {
                return PurchaseTypeCode.CanPurchaseService;
            }

            //已经购买了更高级的版本
            if (userServiceAuthInfos.Any(p => p.AuthType > servicePriceInfo.AuthType))
            {
                return PurchaseTypeCode.PurchaseHigherVersion;
            }

            //已经购买了当前版本的终生版
            if (userServiceAuthInfos.Any(p => p.AuthType == servicePriceInfo.AuthType && p.AuthExpiration == null))
            {
                return PurchaseTypeCode.PurchaseCurrentServiceLifelong;
            }

            return PurchaseTypeCode.CanPurchaseService;

        }

        public async Task<bool> PurchaseSoftwareService(UserInfo user, SalesInfoModel model, int salesManId)
        {
            //获取之前购买的记录，如果为空，则直接购买
            var userServiceAuth = await _userServiceAuthRepository.FirstOrDefaultAsync(
                        p => p.UId == user.Id && p.SId == model.ServiceId);

            var servicePrice = await _servicePriceRepository.FirstOrDefaultAsync(p => p.Id == model.ServicePriceId);
            //历史购买的已经生效的订单
            var historyEffectiveOrder =
                await
                    _userServiceSubscriptionRepository.GetAllListAsync(p => p.UId == user.Id && p.SId == model.ServiceId&&p.State==OrderState.Effective);


            bool isNewPurchase = false;

            if (userServiceAuth == null)
            {
                isNewPurchase = true;
                userServiceAuth = new UserServiceAuthInfo()
                {
                    UId = user.Id,
                    SId = model.ServiceId,
                    AuthType = servicePrice.AuthType,
                };
                userServiceAuth.AuthExpiration = GetAuthExpiration(servicePrice, userServiceAuth, true);
            }
            else
            {
                userServiceAuth.AuthExpiration = GetAuthExpiration(servicePrice, userServiceAuth);
                userServiceAuth.AuthType = servicePrice.AuthType;
                userServiceAuth.UpdateTime = DateTime.Now;
            }


            var userServiceSubscriptionInfo = new UserServiceSubscriptionInfo()
            {
                Id = GetServiceSubscriptionId(),
                UId = user.Id,
                SId = model.ServiceId,
                //SpId = model.ServicePriceId,
                AuthDesc = servicePrice.AuthDesc,
                Cost = model.Cost,
                Profit = model.Cost,
                AuthExpiration = userServiceAuth.AuthExpiration,
                AuthType = userServiceAuth.AuthType,
                Remarks = model.Remarks,
                AdminId = salesManId,
                State = OrderState.Effective,

            };

            using (var uow = _unitOfWorkManager.Begin())
            {
                try
                {
                    if (isNewPurchase)
                    {
                        await _userServiceAuthRepository.InsertAsync(userServiceAuth);
                    }
                    else
                    {
                        await _userServiceAuthRepository.UpdateAsync(userServiceAuth);
                    }
                    if (historyEffectiveOrder != null && historyEffectiveOrder.Count > 0)
                    {
                        foreach (var historyOrder in historyEffectiveOrder)
                        {
                            historyOrder.State = OrderState.Legal;
                            historyOrder.UpdateTime = DateTime.Now;
                            await _userServiceSubscriptionRepository.UpdateAsync(historyOrder);
                        }
                    }
                    await _userServiceSubscriptionRepository.InsertAsync(userServiceSubscriptionInfo);
                    await uow.CompleteAsync();
                    return true;
                }
                catch (Exception e)
                {
                    LogHelper.Logger.Error(string.Format("销售失败，服务器内部错误,单号为{0}", userServiceSubscriptionInfo.Id), e);
                    return false;
                }
            }
        }

       

        public async Task<IList<SalesRecordModel>> GetSalesServiceRecordList()
        {
            var saleRecordList = await _userServiceSubscriptionRepository.GetAllListAsync();

            return saleRecordList.Select(a => new SalesRecordModel()
            {
                Id = a.Id,
                AdminUserName = a.Administrator != null ? a.Administrator.UserName : string.Empty,
                AgentUserName = a.AgentInfo != null ? a.AgentInfo.Id.ToString() : string.Empty,
                AuthExpiration = a.AuthExpiration,
                Cost = a.Cost,
                Profit = a.Profit,
                Remarks = a.Remarks,
                SalesDateTime = a.CreateTime,
                ServiceName = a.AuthDesc,
                UserId = a.User.Id,
                UserName = a.User.UserName,
                UserPhone = a.User.Mobile,
                BrandId = a.ServiceInfo.BrandId,
                ServerInfoId = a.ServiceInfo.Id,
                OrderState = a.State,
            }).ToList();
        }

        public async Task<ResultMessage<string>> UndoSalesOrderById(string id)
        {
            var undoSalesOrder =await _userServiceSubscriptionRepository.GetAsync(id);
            undoSalesOrder.State = OrderState.Invalid;
            undoSalesOrder.UpdateTime = DateTime.Now;
          
            var userServiceAuthInfo = await _userServiceAuthRepository.SingleAsync(p => p.SId == undoSalesOrder.SId && p.UId == undoSalesOrder.UId);

            var userServiceSubscriptionPolicy = new UserServiceSubscriptionPolicy(undoSalesOrder.UId, undoSalesOrder.SId);
            bool isHasRollBackOder = true;
            var rollBackOderInfo = userServiceSubscriptionPolicy.GetRollBackOderInfo(_userServiceSubscriptionRepository,ref isHasRollBackOder);
            if (isHasRollBackOder)
            {
                rollBackOderInfo.State = OrderState.Effective;
                rollBackOderInfo.UpdateTime = DateTime.Now;

                userServiceAuthInfo.AuthExpiration = rollBackOderInfo.AuthExpiration;
                userServiceAuthInfo.AuthType = rollBackOderInfo.AuthType;
                userServiceAuthInfo.UpdateTime = DateTime.Now;
            }
            using (var uow = _unitOfWorkManager.Begin())
            {
                await _userServiceSubscriptionRepository.UpdateAsync(undoSalesOrder);
                if (isHasRollBackOder)
                {
                    await _userServiceSubscriptionRepository.UpdateAsync(rollBackOderInfo);
                    await _userServiceAuthRepository.UpdateAsync(userServiceAuthInfo);
                }
                else
                {
                    await _userServiceAuthRepository.DeleteAsync(userServiceAuthInfo);
                }
                await uow.CompleteAsync();
                return new ResultMessage<string>(string.Format("id为{0}的订单撤销成功!",id));
            }

        }


        private string GetServiceSubscriptionId()
        {
            return string.Format("{0}{1}{2}",
                DateTime.Now.ToString("yyyyMMdd"),
                ToolHelper.GetServiceSeedLine(),
                ToolHelper.GetRandomString(7));
        }


        private DateTime? GetAuthExpiration(ServicePrice servicePrice, UserServiceAuthInfo currentUserServiceAuth, bool isNewPurchase = false)
        {
            if (servicePrice.IsLifeLongVersion)
            {
                return null;
            }

            Debug.Assert(servicePrice.DateYear != null, "servicePrice.DateYear != null");
            if (isNewPurchase)
            {
                return DateTime.Now.AddYears(servicePrice.DateYear.Value)
                      .AddMonths(servicePrice.DateMonth)
                      .AddDays(servicePrice.DateDay);
            }

            if (servicePrice.AuthType > currentUserServiceAuth.AuthType)
            {
                return DateTime.Now.AddYears(servicePrice.DateYear.Value)
                     .AddMonths(servicePrice.DateMonth)
                     .AddDays(servicePrice.DateDay);
            }

            Debug.Assert(currentUserServiceAuth.AuthExpiration != null, "currentUserServiceAuth.AuthExpiration != null");
            if (currentUserServiceAuth.IsActive)
            {
                return currentUserServiceAuth.AuthExpiration.Value.AddYears(servicePrice.DateYear.Value)
                       .AddMonths(servicePrice.DateMonth)
                       .AddDays(servicePrice.DateDay);
            }
            return DateTime.Now.AddYears(servicePrice.DateYear.Value)
                .AddMonths(servicePrice.DateMonth)
                .AddDays(servicePrice.DateDay);
        }
    }
}
