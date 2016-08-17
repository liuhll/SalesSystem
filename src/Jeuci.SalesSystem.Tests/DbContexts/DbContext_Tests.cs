using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Application.Dtos;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.User;
using Jeuci.SalesSystem.Users;
using Shouldly;
using Xunit;

namespace Jeuci.SalesSystem.Tests.DbContexts
{
    public class DbContext_Tests : SalesSystemTestsBase
    {
        private readonly IUserInfoAppService _userInfoAppService;
        public DbContext_Tests()
        {
            _userInfoAppService = LocalIocManager.Resolve<IUserInfoAppService>();
        }

        [Fact]
        public void CanUseDbConext_test()
        {
            var userInfo = UsingDbContext<UserInfo>(context =>
            {
                return context.UserInfos.Find(1);
            });

            userInfo.ShouldNotBeNull();
        }

        [Fact]
        public void CanGetUserInfoByAppUserInfoServer()
        {
            var users = _userInfoAppService.GetAll(new DefaultPagedResultRequest() {});
            users.ShouldNotBeNull("can get users");
        }
    }
}
