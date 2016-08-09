using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using Abp.Events.Bus;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.EventData;
using Jeuci.SalesSystem.Repositories.Interface;

namespace Jeuci.SalesSystem.EntityFramework.Repositories.Impl
{
    public class UserInfoRepository : SalesSystemRepositoryBase<UserInfo>,IUserInfoRepository
    {
        public UserInfoRepository(IDbContextProvider<SalesSystemDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
                   
        }
    
    }
}
