using Abp.EntityFramework;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.User;
using Jeuci.SalesSystem.Repositories.Interface;

namespace Jeuci.SalesSystem.EntityFramework.Repositories.Impl
{
    public class AdministratorInfoRepository : SalesSystemRepositoryBase<AdministratorInfo>, IAdministratorInfoRepository
    {
        public AdministratorInfoRepository(IDbContextProvider<SalesSystemDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
