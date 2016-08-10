using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Jeuci.SalesSystem.Entities
{
    public class AdministratorInfo : Entity, IHasCreationTime
    {
        public AdministratorInfo()
        {
            CreationTime = DateTime.Now;
            State = (int)UserState.Active;
        }

        public string AdminName { get; set; }

        public string Password { get; set; }

        public string RealName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public bool? Sex { get; set; }

        public string WeChat { get; set; }

        public DateTime CreationTime { get; set; }

        public int State { get; set; }

        public string AdminRoles { get; set; }

        public string Brands { get; set; }



    }
}
