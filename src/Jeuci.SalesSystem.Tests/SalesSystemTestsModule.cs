using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Modules;
using Abp.TestBase;

namespace Jeuci.SalesSystem.Tests
{
    [DependsOn(
         typeof(AbpTestBaseModule),
         typeof(SalesSystemDataModule),
         typeof(SalesSystemApplicationModule))]
    public class SalesSystemTestsModule : AbpModule
    {
    }
}
