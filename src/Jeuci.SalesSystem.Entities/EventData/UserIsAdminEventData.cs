using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Events.Bus.Entities;
using Jeuci.SalesSystem.Entities.User;

namespace Jeuci.SalesSystem.Entities.EventData
{

    public class UserIsAdminEventData : EntityCreatedEventData<UserInfo>
    {
        public UserIsAdminEventData(UserInfo entity) : base(entity)
        {

        }

        public bool IsAdmin { get; set; }

        public AdministratorInfo AdministratorInfo { get; set; }
    }
}
  
