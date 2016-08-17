using System.Data.Entity.ModelConfiguration;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping
{
    public class BrandInfoMap : EntityTypeConfiguration<BrandInfo>
    {
        public BrandInfoMap()
        {
            ToTable("BrandInfo");
        }
    }
}
