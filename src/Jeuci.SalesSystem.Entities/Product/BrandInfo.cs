using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace Jeuci.SalesSystem.Entities
{
    public class BrandInfo : Entity<int>
    {
        public string BrandName { get; set; }

        public State State { get; set; }

        public virtual ICollection<ServiceInfo> ServiceInfos { get; set; }
    }
}
