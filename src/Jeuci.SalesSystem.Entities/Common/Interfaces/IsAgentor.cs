using Jeuci.SalesSystem.Entities.User;

namespace Jeuci.SalesSystem.Entities.Common.Interfaces
{
    public interface IIsAgentor
    {
        bool IsAgentor { get; }

        AgentInfo AgentInfo { get; }
    }
}
