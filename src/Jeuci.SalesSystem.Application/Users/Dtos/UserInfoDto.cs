using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Jeuci.SalesSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Users.Dtos
{
    [AutoMap(typeof(UserInfo))]
    public class UserInfoDto : EntityRequestInput
    {
        public string UserName { get; set; }

        //public string Password { get; set; }

        //public string PayPassword { get; set; }

        //public string Mobile { get; set; }

        //public string Email { get; set; }

        //public string WeChat { get; set; }

        //public string QQ { get; set; }

        //public string NickName { get; set; }

        //public byte? Sex { get; set; }

        //public string SafeMobile { get; set; }

        //public string SafeEmail { get; set; }

        //public DateTime RegTime { get; set; }

        //public int State { get; set; }

        //public int? AppType { get; set; }

        //public string IP { get; set; }

        ///// <summary>
        ///// 从哪个服务注册的
        ///// </summary>
        //public int? SID { get; set; }
    }
}
