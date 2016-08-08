using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Collections;
using Abp.Modules;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using Effort;
using EntityFramework.DynamicFilters;
using Jeuci.SalesSystem.EntityFramework;
using Jeuci.SalesSystem.Migrations.SeedData;

namespace Jeuci.SalesSystem.Test
{
    public abstract class SalesSystemTestBase : AbpIntegratedTestBase<SalesSystemTestModule>
    {
        private DbConnection _hostDb;

        protected SalesSystemTestBase()
        {
           
            //Seed initial data
        //    UsingDbContext(context => new InitialDataBuilder(context).Build());

         //   LoginAsDefaultTenantAdmin();
        }

        protected override void PreInitialize()
        {
            base.PreInitialize();

            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );
        }


        private void UseSingleDatabase()
        {
            _hostDb = DbConnectionFactory.CreateTransient();

            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(() => _hostDb)
                    .LifestyleSingleton()
                );
        }

        #region UsingDbContext

        protected void UsingDbContext(Action<SalesSystemDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<SalesSystemDbContext>())
            {
                context.DisableAllFilters();
                action(context);
                context.SaveChanges();
            }
        }

        protected async Task UsingDbContextAsync(Action<SalesSystemDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<SalesSystemDbContext>())
            {
                context.DisableAllFilters();
                action(context);
                await context.SaveChangesAsync();
            }
        }

        protected T UsingDbContext<T>(Func<SalesSystemDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<SalesSystemDbContext>())
            {
                context.DisableAllFilters();
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected async Task<T> UsingDbContextAsync<T>(Func<SalesSystemDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<SalesSystemDbContext>())
            {
                context.DisableAllFilters();
                result = await func(context);
                await context.SaveChangesAsync();
            }

            return result;
        }

        #endregion



        #region UsingDbContext

        //protected IDisposable UsingTenantId(int? tenantId)
        //{
        //    if (tenantId != null)
        //    {
        //        var previousTenantId = AbpSession.TenantId;
        //        AbpSession.TenantId = tenantId;
        //        return new DisposeAction(() => AbpSession.TenantId = previousTenantId);
        //    }
        //    return new DisposeAction(() => { });
          
        //}

        //protected void UsingDbContext(Action<SalesSystemDbContext> action)
        //{
        //    //   UsingDbContext(AbpSession.TenantId, action);
        //    UsingDbContext(null, action);
        //}

        //protected Task UsingDbContextAsync(Action<SalesSystemDbContext> action)
        //{
        //    return UsingDbContextAsync(AbpSession.TenantId, action);
        //}

        //protected T UsingDbContext<T>(Func<SalesSystemDbContext, T> func)
        //{
        //    return UsingDbContext(AbpSession.TenantId, func);
        //}

        //protected Task<T> UsingDbContextAsync<T>(Func<SalesSystemDbContext, Task<T>> func)
        //{
        //    return UsingDbContextAsync(AbpSession.TenantId, func);
        //}

        //protected void UsingDbContext(int? tenantId, Action<SalesSystemDbContext> action)
        //{
        //    using (UsingTenantId(tenantId))
        //    {
        //        using (var context = LocalIocManager.Resolve<SalesSystemDbContext>())
        //        {
        //            context.DisableAllFilters();
        //            action(context);
        //            context.SaveChanges();
        //        }
        //    }
        //}

        //protected async Task UsingDbContextAsync(int? tenantId, Action<SalesSystemDbContext> action)
        //{
        //    using (UsingTenantId(tenantId))
        //    {
        //        using (var context = LocalIocManager.Resolve<SalesSystemDbContext>())
        //        {
        //            context.DisableAllFilters();
        //            action(context);
        //            await context.SaveChangesAsync();
        //        }
        //    }
        //}

        //protected T UsingDbContext<T>(int? tenantId, Func<SalesSystemDbContext, T> func)
        //{
        //    T result;

        //    using (UsingTenantId(tenantId))
        //    {
        //        using (var context = LocalIocManager.Resolve<SalesSystemDbContext>())
        //        {
        //            context.DisableAllFilters();
        //            result = func(context);
        //            context.SaveChanges();
        //        }
        //    }

        //    return result;
        //}

        //protected async Task<T> UsingDbContextAsync<T>(int? tenantId, Func<SalesSystemDbContext, Task<T>> func)
        //{
        //    T result;

        //    using (UsingTenantId(tenantId))
        //    {
        //        using (var context = LocalIocManager.Resolve<SalesSystemDbContext>())
        //        {
        //            context.DisableAllFilters();
        //            result = await func(context);
        //            await context.SaveChangesAsync();
        //        }
        //    }

        //    return result;
        //}

        #endregion
    }
}
