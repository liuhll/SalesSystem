using System.Data.Entity.ModelConfiguration;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping.SalesMapping
{
    public class UserServiceSubscriptionInfoMap : EntityTypeConfiguration<UserServiceSubscriptionInfo>
    {
        public UserServiceSubscriptionInfoMap()
        {
            ToTable("UserServiceSubscriptionInfo");

            HasRequired(t => t.ServiceInfo)
                .WithMany(p => p.UserServiceSubscriptionInfos)
                .HasForeignKey(t => t.SId);

            HasRequired(t => t.User)
                .WithMany(p => p.UserServiceSubscriptionInfos)
                .HasForeignKey(t => t.UId);


            HasOptional(t => t.AgentInfo)
                .WithMany(t => t.UserServiceSubscriptionInfos)
                .HasForeignKey(t => t.AgentId);

            HasOptional(t => t.Administrator)
             .WithMany(t => t.UserServiceSubscriptionInfos)
             .HasForeignKey(t => t.AdminId);
        }
    }
}
