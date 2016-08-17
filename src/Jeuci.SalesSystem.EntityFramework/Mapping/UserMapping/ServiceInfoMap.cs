using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping
{
    public class ServiceInfoMap : EntityTypeConfiguration<ServiceInfo>
    {
        public ServiceInfoMap()
        {
            ToTable("ServiceInfo");
            HasRequired(t => t.BrandInfo)
                .WithMany(t => t.ServiceInfos)
                .HasForeignKey(t => t.BrandId);

        }
    }
}
