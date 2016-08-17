using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common.Enums;

namespace Jeuci.SalesSystem.Services.Dtos
{
    [AutoMap(typeof(ServicePrice))]
    public class ServicePriceDto : EntityRequestInput<int>
    {
        public int ServiceId { get; set; }

        public ServiceInfoDto ServerInfo { get; set; }

        public decimal Price { get; set; }

        public decimal AgentPrice { get; set; }

        public int? DateYear { get; set; }

        public int DateMonth { get; set; }

        public int DateDay { get; set; }

        public string AuthDesc { get; set; }

        public string Description { get; set; }

        public AuthType AuthType { get; set; }

        public State State { get; set; }

    }
}
