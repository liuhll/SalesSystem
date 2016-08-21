using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Abp.Application.Services.Dto;
using Jeuci.SalesSystem.Application.Dtos;
using Jeuci.SalesSystem.Data;
using Jeuci.SalesSystem.Sales;
using Jeuci.SalesSystem.Sales.Dtos;
using Newtonsoft.Json;

namespace Jeuci.SalesSystem.Api.Controllers
{
    public class SalesRecordController : ApiController
    {
        private readonly ISaleSoftwareAppService _saleSoftwareAppService;

        public SalesRecordController(ISaleSoftwareAppService saleSoftwareAppService)
        {
            _saleSoftwareAppService = saleSoftwareAppService;
        }

        [HttpGet]
        public async Task<BootstrapTablePagedResult<SalesRecordOutput>> GetList([FromUri] SalesRecordSearchInput searchInput)
        {
            var recordList =await _saleSoftwareAppService.GetSalesServiceRecordPageList(searchInput);
            return recordList;
        }

    }
}
