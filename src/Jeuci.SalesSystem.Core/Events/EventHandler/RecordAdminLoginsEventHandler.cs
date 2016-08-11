using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Jeuci.SalesSystem.Events.EventData;
using Jeuci.SalesSystem.Repositories.Interface;

namespace Jeuci.SalesSystem.Events.EventHandler
{
    public class RecordAdminLoginsEventHandler : IEventHandler<AdminLoginsEventData>, ITransientDependency
    {
        private readonly IAdminLoginHistoryRepository _adminLoginHistoryRepository;

        public RecordAdminLoginsEventHandler(IAdminLoginHistoryRepository adminLoginHistoryRepository)
        {
            _adminLoginHistoryRepository = adminLoginHistoryRepository;
        }

        public void HandleEvent(AdminLoginsEventData eventData)
        {
           _adminLoginHistoryRepository.Insert(eventData.Entity);         
        }
    }
}
