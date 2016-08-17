using System.Data.Entity.ModelConfiguration;
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
