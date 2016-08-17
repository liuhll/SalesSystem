using System.Data.Entity.ModelConfiguration;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Mapping.UserMapping
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
