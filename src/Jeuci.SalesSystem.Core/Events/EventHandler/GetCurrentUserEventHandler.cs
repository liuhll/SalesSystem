using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Handlers;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Events.EventData;

namespace Jeuci.SalesSystem.Events.EventHandler
{
    public class GetCurrentUserEventHandler<TUser> : IEventHandler<CurrentUserInfoEventData<TUser>> 
        where TUser : UserBase
    {
        private readonly IRepository<TUser> _userRepository;
        public GetCurrentUserEventHandler(IRepository<TUser> useRepository)
        {
            _userRepository = useRepository;
        }

        public void HandleEvent(CurrentUserInfoEventData<TUser> eventData)
        {
            var currentUser = _userRepository.Get(eventData.Entity);
            eventData.CurrentUser = currentUser;
        }
    }
}
