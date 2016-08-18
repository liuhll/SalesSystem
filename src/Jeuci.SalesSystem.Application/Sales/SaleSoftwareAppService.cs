using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Jeuci.SalesSystem.Domain.Sales;
using Jeuci.SalesSystem.Domain.Sales.Models;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common;
using Jeuci.SalesSystem.Entities.Common.Enums;
using Jeuci.SalesSystem.Sales.Dtos;

namespace Jeuci.SalesSystem.Sales
{
    public class SaleSoftwareAppService : ISaleSoftwareAppService
    {

        private readonly IRepository<UserInfo> _userInfoRepository;
        private readonly ISalesSoftwareProcessor _salesSoftwareProcessor;

        public SaleSoftwareAppService(
            IRepository<UserInfo> userInfoRepository,
            ISalesSoftwareProcessor salesSoftwareProcessor)
        {
            _userInfoRepository = userInfoRepository;
            _salesSoftwareProcessor = salesSoftwareProcessor;
        }


        public async Task<SalesResultMessage> SalesSoftwareService(SalesInput model, int salesManId)
        {
            var userInfo = await _userInfoRepository.FirstOrDefaultAsync(
                p => p.UserName == model.Passport || p.Mobile == model.Passport);

            //不存在的用户
            if (userInfo == null)
            {
                return new SalesResultMessage(SalesResultType.NullUser);
            }

            //被冻结的用户
            if (!userInfo.IsActive)
            {
                return new SalesResultMessage(SalesResultType.InvalidUser);
            }

            var purchaseTypeCode = await _salesSoftwareProcessor.IsPurchaseHigherVersion(userInfo, model.ServicePriceId);

            //用户购买了比用户当前生效的更低版本的软件服务
            if (purchaseTypeCode == PurchaseTypeCode.PurchaseHigherVersion)
            {
                return new SalesResultMessage(SalesResultType.ExistHighVersion);
            }

            //用户购买了终身版本
            if (purchaseTypeCode == PurchaseTypeCode.PurchaseCurrentServiceLifelong)
            {
                return new SalesResultMessage(SalesResultType.PurchaseCurrentServiceLifelong);
            }
            //成功购买
            if (await _salesSoftwareProcessor.PurchaseSoftwareService(userInfo, model.MapTo<SalesInfoModel>(), salesManId))
            {
                return new SalesResultMessage(SalesResultType.Success);
            }

            return new SalesResultMessage(SalesResultType.Other);
        }
    }
}
