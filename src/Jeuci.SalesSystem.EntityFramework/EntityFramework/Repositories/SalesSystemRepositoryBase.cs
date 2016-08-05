using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Jeuci.SalesSystem.Repositories;

namespace Jeuci.SalesSystem.EntityFramework.Repositories
{
    public abstract class SalesSystemRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SalesSystemDbContext, TEntity, TPrimaryKey> , ISalesSystemRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SalesSystemRepositoryBase(IDbContextProvider<SalesSystemDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class SalesSystemRepositoryBase<TEntity> : SalesSystemRepositoryBase<TEntity, int> , ISalesSystemRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        protected SalesSystemRepositoryBase(IDbContextProvider<SalesSystemDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
