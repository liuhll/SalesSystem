using System.Data.Entity.ModelConfiguration;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping
{
    public class UserServiceAuthInfoMap : EntityTypeConfiguration<UserServiceAuthInfo>
    {
        public UserServiceAuthInfoMap()
        {
            ToTable("UserServiceAuthInfo");
            HasKey(t=>new {t.UId,t.SId});
        }
    }
}
