using System.Data.Entity.ModelConfiguration;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping.UserMapping
{
    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            ToTable("UserInfo");

            Ignore(t => t.IsAgentor);

            Ignore(t => t.AgentInfo);
          
        }
    }
}
