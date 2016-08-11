using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace Jeuci.SalesSystem.Entities
{
    public abstract class UserBase :Entity, IUser<int>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string WeChat { get; set; }

        public int State { get; set; }

        public bool IsActive
        {
            get { return (UserState)Enum.ToObject(typeof(UserState), State) == UserState.Active; }
        }

    }
}
