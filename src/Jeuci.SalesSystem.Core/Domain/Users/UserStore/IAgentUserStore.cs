using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Domain.Users.UserStore
{
    public interface IAgentUserStore : IJueciUserStoreBase<UserInfo>
    {
    }
}
