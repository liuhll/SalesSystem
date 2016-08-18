using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Jeuci.SalesSystem.AutoMapper;

namespace Jeuci.SalesSystem
{
    [DependsOn(typeof(SalesSystemCoreModule), typeof(AbpAutoMapperModule))]
    public class SalesSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            ModelMapperConfiguration.ConfigModelMapper();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
