using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Handlers;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Events.EventData;

namespace Jeuci.SalesSystem.Events.EventHandler
{
   public class CurrentUserEventHandler : IEventHandler<CurrentUserEventData>, ITransientDependency    
   {
       private readonly IRepository<AdministratorInfo,int> _userRepository;
       public CurrentUserEventHandler(IRepository<AdministratorInfo, int> userRepository)
       {
           _userRepository = userRepository;
       }

       public void HandleEvent(CurrentUserEventData eventData)
       {
           var currentUser = _userRepository.Get(eventData.CurrentUserId);
           eventData.CurrentUser = currentUser;
       }
    }
}
