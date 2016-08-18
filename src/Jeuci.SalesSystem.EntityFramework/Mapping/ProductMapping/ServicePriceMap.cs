using System.Data.Entity.ModelConfiguration;
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

            Ignore(t => t.IsLifeLongVersion);
        }
    }
}
