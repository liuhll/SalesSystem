using System.Reflection;
using Abp.Modules;
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
