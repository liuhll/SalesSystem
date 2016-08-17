using System;
using Abp.Domain.Entities.Auditing;
using Jeuci.SalesSystem.Entities.Common.Enums;

namespace Jeuci.SalesSystem.Entities
{
    public class AdministratorInfo : UserBase, IHasCreationTime
    {
        public AdministratorInfo()
        {
            CreationTime = DateTime.Now;
            State = (int)UserState.Active;
        }

    //    public string AdminName { get; set; }

        public string RealName { get; set; }

        public bool? Sex { get; set; }

        public DateTime CreationTime { get; set; }

        public string AdminRoles { get; set; }

        public string Brands { get; set; }


    }
}
