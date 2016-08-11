using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Entities.Common.Enums
{
    public enum LoginResultType
    {
        Success = 1,
        InvalidUserName = 2,
        InvalidPassword = 3,
        UserIsNotActive = 4,
        UserEmailIsNotConfirmed = 5,
        UnknownExternalLogin = 6,
    }
}
