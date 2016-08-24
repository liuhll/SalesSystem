using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Domain.Users.UserStore.impl
{
    public class AgentUserStore : IAgentUserStore
    {
        public readonly IRepository<UserInfo> _agentRepository;

        public AgentUserStore(IRepository<UserInfo> agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public Task CreateAsync(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public Task<UserInfo> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserInfo> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //No need to dispose since using IOC.
        }
    }
}
