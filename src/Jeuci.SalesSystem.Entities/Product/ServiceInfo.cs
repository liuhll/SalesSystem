using Abp.Domain.Entities;

namespace Jeuci.SalesSystem.Entities
{
    public class ServiceInfo : Entity
    {
        public string ServiceName { get; set; }

        public int? BrandID { get; set; }

        public int State { get; set; }

        public string Remarks { get; set; }

        public int Sort { get; set; }
    }
}
