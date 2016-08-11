using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Repositories.Interface;

namespace Jeuci.SalesSystem.Domain.Users.UserStore.impl
{
    // :TODO 实现管理员的增删改查
    public class AdministratorUserStore : IAdministratorUserStore
    {

        public readonly IAdministratorInfoRepository _administratorInfoRepository;

        public AdministratorUserStore(IAdministratorInfoRepository administratorInfoRepository)
        {
            _administratorInfoRepository = administratorInfoRepository;
        }

        public Task CreateAsync(AdministratorInfo user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AdministratorInfo user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AdministratorInfo user)
        {
            throw new NotImplementedException();
        }

        public Task<AdministratorInfo> FindByIdAsync(int userId)
        {
            return _administratorInfoRepository.GetAsync(userId);
        }

        public Task<AdministratorInfo> FindByNameAsync(string userName)
        {
            return _administratorInfoRepository.FirstOrDefaultAsync(p => p.UserName == userName);
        }

        public virtual void Dispose()
        {
            //No need to dispose since using IOC.
        }
    }
}
