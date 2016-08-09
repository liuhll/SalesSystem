using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Entities.CommonInterfaces
{
    public interface IsAgentor
    {
        bool IsAgentor { get; }

        AgentInfo AgentInfo { get; }
    }
}
