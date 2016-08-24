using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.ModelBinding;
using Jeuci.SalesSystem.Data;
using Jeuci.SalesSystem.Entities.Common;
using Jeuci.SalesSystem.Sales;
using Jeuci.SalesSystem.Sales.Dtos;


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
        [Route("GetList")]
        public async Task<BootstrapTablePagedResult<SalesRecordOutput>> GetList([FromUri] SalesRecordSearchInput searchInput)
        {
            var recordList =await _saleSoftwareAppService.GetSalesServiceRecordPageList(searchInput);
            return recordList;
        }

        [HttpPut]
        [Route("UndoSalesOrder")]
        public async Task<ResultMessage<string>> UndoSalesOrder(string id)
        {
            var result = await _saleSoftwareAppService.UndoSalesOrderById(id);

            return result;
        }
    }
}
