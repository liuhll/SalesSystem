using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Events.Bus.Entities;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Events.EventData
{
    public class AgentLoginsEventData : EntityEventData<AgentLoginHistory>
    {
        public AgentLoginsEventData(AgentLoginHistory entity) : base(entity)
        {
        }
    }
}
