using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace Jeuci.SalesSystem
{
    [DependsOn(typeof(AbpWebApiModule), typeof(SalesSystemApplicationModule))]
    public class SalesSystemWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(SalesSystemApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
