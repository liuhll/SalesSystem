using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Jeuci.SalesSystem.Application.Dtos;
using Jeuci.SalesSystem.Users;
using Shouldly;
using Xunit;

namespace Jeuci.SalesSystem.Tests.DbConnections
{
    public class DbConnection_Tests : SalesSystemTestBase
    {
        private readonly IUserInfoAppService _userInfoAppService;

        public DbConnection_Tests()
        {
            _userInfoAppService = LocalIocManager.Resolve<IUserInfoAppService>();
        }

        [Fact]
        public void UserDemo_Test()
        {
          //  var userdemo = _userInfoAppService.Get(new IdInput() { Id = 1035 });
            var users = _userInfoAppService.GetAll(new DefaultPagedResultRequest() {});
            users.ShouldNotBeNull();
        }
    }
}
