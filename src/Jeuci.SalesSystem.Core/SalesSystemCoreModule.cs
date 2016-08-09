using System.Reflection;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Jeuci.SalesSystem.Domain.Users;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem
{
    [DependsOn(typeof(SalesSystemEntitiesModule))]
    public class SalesSystemCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        
        }
    }
}
