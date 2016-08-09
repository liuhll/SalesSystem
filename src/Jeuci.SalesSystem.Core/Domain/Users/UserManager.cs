using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Repositories.Interface;

namespace Jeuci.SalesSystem.Domain.Users
{
    public class UserInfoManager :  IUserInfoManager
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoManager(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public UserInfo TestMethod()
        {
            return _userInfoRepository.FirstOrDefault(p => p.Id == 1035);

        }
    }
}
