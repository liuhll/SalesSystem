using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping
{
    public class AgentInfoMap : EntityTypeConfiguration<AgentInfo>
    {
        public AgentInfoMap()
        {
            ToTable("AgentInfo");

            HasKey(t => t.Id);

            Property(t => t.Id).HasColumnName("AgentID");
              
            Ignore(t => t.UserId);

        }
    }
}
