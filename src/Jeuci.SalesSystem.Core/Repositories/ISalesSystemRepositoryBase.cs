using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;


namespace Jeuci.SalesSystem.Repositories
{
    public interface ISalesSystemRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {

    }

    public interface ISalesSystemRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {

    }
}
