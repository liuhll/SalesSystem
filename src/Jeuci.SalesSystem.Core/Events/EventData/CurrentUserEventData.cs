using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Events.Bus.Entities;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Events.EventData
{
    public class CurrentUserEventData :EntityEventData<int>
      
    {
        private int _currentUserId;
        public CurrentUserEventData(int currentUserId) : base(currentUserId)
        {
            _currentUserId = currentUserId;
        }

        public AdministratorInfo CurrentUser { get; set; }

        public int CurrentUserId
        {
            get { return _currentUserId; }
        }
    }
}
