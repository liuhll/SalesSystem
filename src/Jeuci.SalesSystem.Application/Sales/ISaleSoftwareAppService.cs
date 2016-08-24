using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common;
using Jeuci.SalesSystem.Sales.Dtos;
using Jeuci.SalesSystem.Data;

namespace Jeuci.SalesSystem.Sales
{
    public interface ISaleSoftwareAppService : IApplicationService
    {
        Task<SalesResultMessage> SalesSoftwareService(SalesInput model, int salesManId);

        //Task<ICollection<SalesRecordOutput>> GetSalesServiceRecordLsit();

        Task<BootstrapTablePagedResult<SalesRecordOutput>> GetSalesServiceRecordPageList(SalesRecordSearchInput searchInput);
        Task<ResultMessage<string>> UndoSalesOrderById(string id);
    }
}

