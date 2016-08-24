using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common.Enums;

namespace Jeuci.SalesSystem.Domain.Sales.Policy
{
    public class UserServiceSubscriptionPolicy
    {
        private int _userId;
        private int _serviceId;

        public UserServiceSubscriptionPolicy(int userId, int serviceId)
        {
            _userId = userId;
            _serviceId = serviceId;
        }

        public UserServiceSubscriptionInfo GetRollBackOderInfo(IRepository<UserServiceSubscriptionInfo,string> repository,ref bool isHasRollBackOder)
        {
            var subscriptionHistoryLegalList =  
                repository.GetAllList(p => p.State == OrderState.Legal && p.UId == _userId && p.SId == _serviceId);
            if (subscriptionHistoryLegalList.Count <= 0)
            {
                isHasRollBackOder = false;
                return null;
            }
            return
                subscriptionHistoryLegalList.OrderByDescending(p => p.AuthType)
                    .ThenByDescending(p => p.CreateTime)
                    .FirstOrDefault();
        }
    }
}
