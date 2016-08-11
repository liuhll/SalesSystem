using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Collections;
using Abp.Dependency;

namespace Jeuci.SalesSystem.Configuration
{
    public interface IUserManagementConfig : ITransientDependency
    {
        ITypeList<object> ExternalAuthenticationSources { get; set; }
    }
}
