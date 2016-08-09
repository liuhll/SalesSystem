using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Events.Bus.Entities;

namespace Jeuci.SalesSystem.Entities.EventData
{

    public class UserInfoIsAdminEventData : EntityCreatedEventData<UserInfo>
    {
        public UserInfoIsAdminEventData(UserInfo entity) : base(entity)
        {

        }

        public bool IsAdmin { get; set; }

        public AdministratorInfo AdministratorInfo { get; set; }
    }
}
  
