using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping
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
