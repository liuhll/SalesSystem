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
using Jeuci.SalesSystem.Entities.Common.Enums;
using Jeuci.SalesSystem.Helper;

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
            bool isNewPurchase = false;

            if (userServiceAuth == null)
            {
                isNewPurchase = true;
                userServiceAuth = new UserServiceAuthInfo()
                {
                    UId = user.Id,
                    SId = model.ServicePriceId,
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

       

        public async Task<IList<SalesRecordModel>> GetSalesServiceRecordPagedList()
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
                ServerInfoId = a.ServiceInfo.Id
            }).ToList();
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
