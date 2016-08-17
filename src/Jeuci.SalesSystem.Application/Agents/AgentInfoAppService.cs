using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Jeuci.SalesSystem.Agents.Dtos;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.User;

namespace Jeuci.SalesSystem.Agents
{
    public class AgentInfoAppService : CrudAppService<AgentInfo, AgentInfoDto>, IAgentInfoAppService
    {
        public AgentInfoAppService(IRepository<AgentInfo, int> repository) : base(repository)
        {
        }

        //public override PagedResultOutput<AgentInfoDto> GetAll(DefaultPagedResultRequest input)
        //{
        //    var query = CreateQueryable(input);

        //    //return new PagedResultOutput<AgentInfoDto>(
        //    //    query.Count(),
        //    //    CreateQueryable(input).OrderByDescending(e => e.AgentID).PageBy(input).MapTo<List<AgentInfoDto>>()
        //    //    );
        //    return null;
        //}

    }
}
