using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping
{
    public class ServicePriceMap : EntityTypeConfiguration<ServicePrice>
    {
        public ServicePriceMap()
        {
            ToTable("ServicePrice");
            HasRequired(t => t.ServerInfo)
                .WithMany(t => t.ServicePrices)
                .HasForeignKey(t => t.ServiceId);
        }
    }
}
