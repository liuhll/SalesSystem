using System.Reflection;
using Abp.Modules;
using Abp.TestBase;

namespace Jeuci.SalesSystem.Tests
{
    [DependsOn(
        typeof(AbpTestBaseModule),
        typeof(SalesSystemDataModule),
        typeof(SalesSystemApplicationModule))]
    public class SalesSystemTestModule : AbpModule
    {
        public override void Initialize()
        {
           IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }

}
