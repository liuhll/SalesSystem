using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping
{
    public class AdministratorInfoMap : EntityTypeConfiguration<AdministratorInfo>
    {
        public AdministratorInfoMap()
        {
            ToTable("AdministratorInfo");

            Property(t => t.UserName).IsRequired().HasColumnName("AdminName");

            Property(t => t.State).IsRequired();

            Property(t => t.CreationTime).HasColumnName("CeateTime");

            Property(t => t.AdminRoles).IsRequired();

            Property(t => t.Brands).IsRequired();

            Ignore(t => t.IsActive);

        }
    }
}
