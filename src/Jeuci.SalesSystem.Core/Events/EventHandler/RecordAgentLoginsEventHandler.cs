using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Handlers;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Events.EventData;

namespace Jeuci.SalesSystem.Events.EventHandler
{
    public class RecordAgentLoginsEventHandler : IEventHandler<AgentLoginsEventData>, ITransientDependency
    {
        private readonly IRepository<AgentLoginHistory> _agentLoginHistoryRepository;

        public RecordAgentLoginsEventHandler(IRepository<AgentLoginHistory> agentLoginHistoryRepository)
        {
            _agentLoginHistoryRepository = agentLoginHistoryRepository;
        }

        public void HandleEvent(AgentLoginsEventData eventData)
        {
            _agentLoginHistoryRepository.Insert(eventData.Entity);
        }
    }
}
