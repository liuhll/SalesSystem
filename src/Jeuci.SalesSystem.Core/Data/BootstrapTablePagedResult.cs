using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace Jeuci.SalesSystem.Data
{
    public class BootstrapTablePagedResult<TDto>
        where TDto : IOutputDto
    {

        public BootstrapTablePagedResult(int total, ICollection<TDto> rows)
        {
            Total = total;
            Rows = rows;
        }

        public BootstrapTablePagedResult(PagedResultOutput<TDto> output)
        {
            Total = output.TotalCount;
            Rows = output.Items.ToList();
        }

        public int Total { get; }

        public ICollection<TDto> Rows { get; }
    }
}
