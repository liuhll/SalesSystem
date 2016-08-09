using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Jeuci.SalesSystem.Entities.EventData;

namespace Jeuci.SalesSystem.Events.EventHandler
{
    public class AssertUserInfoIsAdminEventHandler : IEventHandler<UserInfoIsAdminEventData>, ITransientDependency
    {
        //todo : 判断用户是否为管理员
        public void HandleEvent(UserInfoIsAdminEventData eventData)
        {
            throw new NotImplementedException();
        }
    }
}
