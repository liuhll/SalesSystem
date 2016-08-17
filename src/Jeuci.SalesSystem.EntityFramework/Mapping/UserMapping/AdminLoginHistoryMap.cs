using System.Data.Entity.ModelConfiguration;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping.UserMapping
{
    public class AdminLoginHistoryMap : EntityTypeConfiguration<AdminLoginHistory>
    {
        public AdminLoginHistoryMap()
        {
            HasKey(t => t.Id);

            ToTable("AdminLoginHistory");

            //HasRequired(t => t.Administrator)
            //    .WithMany()
            //    .HasForeignKey(t => t.AdminID);
        }
    }
}
