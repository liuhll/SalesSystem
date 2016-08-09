using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Handlers;
using Abp.Logging;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.EventData;
using Jeuci.SalesSystem.Repositories.Interface;

namespace Jeuci.SalesSystem.Events.EventHandler
{
    public class AssertUserInfoIsAgentorEventHandler : IEventHandler<UserInfoIsAgentorEventData>, ITransientDependency
    {
        private readonly IRepository<AgentInfo> _agentInfoRepository;
        
        public AssertUserInfoIsAgentorEventHandler(IRepository<AgentInfo> agentInfoRepository)
        {
            _agentInfoRepository = agentInfoRepository;
           
        }

        public void HandleEvent(UserInfoIsAgentorEventData eventData)
        {
            try
            {
                var agentInfo = _agentInfoRepository.Get(eventData.Entity.Id);
                if (agentInfo != null)
                {
                  //  eventData.IsAdministrator = true;
                    eventData.IsAgentor = true;
                    eventData.AgentInfo = agentInfo;
                }
            }
            catch (Exception e)
            {
                eventData.IsAgentor = false;      
                eventData.AgentInfo = null;
                LogHelper.Logger.Debug(string.Format("Id为：{0}的用户不是代理商", eventData.Entity.Id));               
            }

           
        }
    }
}
