using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;

namespace Jeuci.SalesSystem.Domain.Users.Authorization
{
    public class JeuciAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages_admin = context.GetPermissionOrNull(PermissionNames.Pages_Admin) ??
                              context.CreatePermission(PermissionNames.Pages_Admin);

            var pages_agent = context.GetPermissionOrNull(PermissionNames.Pages_Agent) ??
                              context.CreatePermission(PermissionNames.Pages_Agent);
        }
    }
}
