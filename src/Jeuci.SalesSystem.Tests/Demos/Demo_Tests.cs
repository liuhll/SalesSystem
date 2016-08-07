using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Users;
using Shouldly;
using Xunit;

namespace Jeuci.SalesSystem.Tests.Demos
{
    public class Demo_Tests : SalesSystemTestBase
    {
        private readonly IUserInfoAppService _userInfoAppService;

        public Demo_Tests()
        {
            _userInfoAppService = LocalIocManager.Resolve<IUserInfoAppService>();
        }

        [Fact]
        public void Context_Test()
        {
            var testData = UsingDbContext<IList<UserInfo>>(context =>
             {
                 var returnData = context.UserInfos.Where(p => 1 == 1).ToList();
                 return returnData;
             });

            testData.ShouldNotBeNull();
            testData.ShouldNotBeEmpty();
        }

        [Fact]
        public void UserDemo_Test()
        {
            var userdemo = _userInfoAppService.Get(new IdInput() { Id = 1035 });
            userdemo.ShouldNotBeNull();           
        }
    }
}
