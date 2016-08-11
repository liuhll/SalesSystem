using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Collections;

namespace Jeuci.SalesSystem.Configuration
{
    public class UserManagementConfig : IUserManagementConfig
    {
        public ITypeList<object> ExternalAuthenticationSources { get; set; }

        public UserManagementConfig()
        {
            ExternalAuthenticationSources = new TypeList();
        }
    }
}
