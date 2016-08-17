using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
