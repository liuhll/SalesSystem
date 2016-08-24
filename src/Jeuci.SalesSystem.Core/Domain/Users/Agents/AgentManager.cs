using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Jeuci.SalesSystem.Domain.Users.UserStore;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common.Enums;

namespace Jeuci.SalesSystem.Domain.Users.Agents
{
    public class AgentManager : UserManagerBase<UserInfo>, IAgentManager
    {
        public AgentManager(IRepository<UserInfo> userRepository, IAgentUserStore userStore) 
            : base(userRepository, userStore, UserRole.Agent)
        {
        }
    }
}
