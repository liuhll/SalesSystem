using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Jeuci.SalesSystem.EntityFramework;

namespace Jeuci.SalesSystem
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(SalesSystemCoreModule))]
    public class SalesSystemDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<SalesSystemDbContext>(null);
        }
    }
}
