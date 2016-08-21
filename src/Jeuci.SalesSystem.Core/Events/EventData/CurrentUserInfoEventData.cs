using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Events.Bus.Entities;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Events.EventData
{
    public class CurrentUserInfoEventData<TUser> : EntityEventData<int>
        where TUser : UserBase
    {
        public TUser CurrentUser { get; set; }

        public CurrentUserInfoEventData(int entity) : base(entity)
        {

        }
    }
}
