using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;


namespace Jeuci.SalesSystem.Mapping
{
    public class AdminLoginHistoryMap : EntityTypeConfiguration<AdminLoginHistory>
    {
        public AdminLoginHistoryMap()
        {
            HasKey(t => t.Id);

            ToTable("AdminLoginHistory");

            Ignore(t => t.Administrator);

            //HasRequired(t => t.Administrator)
            //    .WithMany()
            //    .HasForeignKey(t => t.AdminID);
        }
    }
}
