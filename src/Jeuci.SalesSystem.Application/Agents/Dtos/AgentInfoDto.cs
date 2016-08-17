using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.User;

namespace Jeuci.SalesSystem.Agents.Dtos
{
    [AutoMap(typeof(AgentInfo))]
    public class AgentInfoDto : EntityRequestInput
    {

        public DateTime CreateTime { get; set; }

        public int State { get; set; }

        public decimal Discount { get; set; }

        public string AgentType { get; set; }

        public string AuthType { get; set; }

        public string Website { get; set; }
    }
}
