using System.Data.Entity.ModelConfiguration;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping.SalesMapping
{
    public class UserServiceSubscriptionInfoMap : EntityTypeConfiguration<UserServiceSubscriptionInfo>
    {
        public UserServiceSubscriptionInfoMap()
        {
            ToTable("UserServiceSubscriptionInfo");
        }
    }
}
