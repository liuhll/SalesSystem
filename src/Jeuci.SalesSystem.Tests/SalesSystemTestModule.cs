using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Modules;
using Abp.TestBase;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Tests
{
    [DependsOn(
         typeof(AbpTestBaseModule),
         typeof(SalesSystemDataModule),
         typeof(SalesSystemApplicationModule),
         typeof(SalesSystemEntitiesModule))]
    public class SalesSystemTestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
