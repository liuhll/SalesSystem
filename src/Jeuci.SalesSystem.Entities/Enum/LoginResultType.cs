using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Entities.Enum
{
    public enum LoginResultType :  byte
    {
        Success = 1,
        InvalidUserNameOrEmailAddress = 2,
        InvalidPassword = 3,
        UserIsNotActive = 4,
        InvalidTenancyName = 5,
        TenantIsNotActive = 6,
        UserEmailIsNotConfirmed = 7,
        UnknownExternalLogin = 8,
    }
}
