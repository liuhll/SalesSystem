using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Domain.Users;
using Jeuci.SalesSystem.Entities.Common.Enums;
using Jeuci.SalesSystem.Helper;
using Shouldly;
using Xunit;

namespace Jeuci.SalesSystem.Tests.Users
{
    public class Administrator_Tests : SalesSystemTestsBase
    {
        private readonly IAdministratorManager _administratorManager;
        public Administrator_Tests()
        {
            _administratorManager = LocalIocManager.Resolve<IAdministratorManager>();
        }

        [Fact]
        public void AdministratorLogin_Test()
        {
            var userName = "Admin";
            var password = Hash256Helper.GetUserSignByHash256(userName, "E0BC60C82713F64EF8A57C0C40D02CE24FD0141D5CC3086259C19B1E62A62BEA");
            var loginResult =_administratorManager.LoginAsync(userName,password);
            loginResult.ShouldNotBeNull();
            loginResult.Result.Result.ShouldBe(LoginResultType.Success);

        }
    }
}
