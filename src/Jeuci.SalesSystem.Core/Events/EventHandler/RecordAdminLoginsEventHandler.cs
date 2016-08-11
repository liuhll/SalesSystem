using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Events.Bus;
using Abp.Events.Bus.Handlers;
using Jeuci.SalesSystem.Entities.EventData;
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

        public async void HandleEvent(AdminLoginsEventData eventData)
        {
           await _adminLoginHistoryRepository.InsertAsync(eventData.Entity);
        }
    }
}
