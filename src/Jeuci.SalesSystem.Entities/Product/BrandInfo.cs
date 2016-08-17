using System.Collections.Generic;
using Abp.Domain.Entities;
using Jeuci.SalesSystem.Entities.Common.Enums;

namespace Jeuci.SalesSystem.Entities
{
    public class BrandInfo : Entity<int>
    {
        public string BrandName { get; set; }

        public State State { get; set; }

        public virtual ICollection<ServiceInfo> ServiceInfos { get; set; }
    }
}
