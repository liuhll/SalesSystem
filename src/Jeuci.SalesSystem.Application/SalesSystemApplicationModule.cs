using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Jeuci.SalesSystem
{
    [DependsOn(typeof(SalesSystemCoreModule), typeof(AbpAutoMapperModule))]
    public class SalesSystemApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
