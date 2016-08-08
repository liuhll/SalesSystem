using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Modules;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Installer;
using Jeuci.SalesSystem.Assistant.Test;
using Jeuci.SalesSystem.EntityFramework;

namespace Jeuci.SalesSystem.Test
{
    [DependsOn(typeof(SalesSystemAssistantTestModule), typeof(AbpTestBaseModule))]
    public class SalesSystemTestModule : AbpModule
    {
     
    }
}
