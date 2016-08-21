using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Jeuci.SalesSystem.Domain.Sales.Models;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common.Enums;

namespace Jeuci.SalesSystem.Domain.Sales
{
    public interface ISalesSoftwareProcessor : ITransientDependency
    {
        /// <summary>
        /// --0 未购买更高本版或是终身版
        /// --1 已经购买了当前版本的终身版
        /// --2 已经购买了更高版本
        /// </summary>
        /// <param name="user"></param>
        /// <param name="servicePriceId"></param>
        /// <returns></returns>
        Task<PurchaseTypeCode> IsPurchaseHigherVersion(UserInfo user, int servicePriceId);

        Task<bool> PurchaseSoftwareService(UserInfo user,SalesInfoModel model,int salesManId);

        Task<ICollection<SalesRecordModel>> GetSalesServiceRecordLsit();

        IQueryable<SalesRecordModel> GetSalesServiceRecordPagedLsit();

    }
}