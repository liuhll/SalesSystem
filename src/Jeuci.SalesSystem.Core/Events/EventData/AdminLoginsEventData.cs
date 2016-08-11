using Abp.Events.Bus.Entities;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Events.EventData
{
    public class AdminLoginsEventData : EntityCreatedEventData<AdminLoginHistory>    
    {
        public AdminLoginsEventData(AdminLoginHistory entity) : base(entity)
        {
        }

    }
}
