using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using Effort;
using EntityFramework.DynamicFilters;
using Jeuci.SalesSystem.EntityFramework;
using Jeuci.SalesSystem.Migrations.SeedData;

namespace Jeuci.SalesSystem.Tests
{
    public class SalesSystemTestBase : AbpIntegratedTestBase<SalesSystemTestModule>
    {
        protected SalesSystemTestBase()
        {
        //    UsingDbContext(context =>
        //    {
        //        new InitialDbBuilder(context).Create();
        //        new TestDataCreator(context).Create();
        //    });
        }

        protected override void PreInitialize()
        {
   
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );

            base.PreInitialize();
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
                context.Database.CreateIfNotExists();
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
                context.Database.CreateIfNotExists();
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
                context.Database.CreateIfNotExists();
                context.DisableAllFilters();
                result = await func(context);
                await context.SaveChangesAsync();
            }

            return result;
        }

        #endregion
    }
}
