using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Jeuci.SalesSystem.Domain.Sales.Models;

namespace Jeuci.SalesSystem.Data
{
    public class BootstrapTablePagedResult<TDto>
        where TDto : IOutputDto
    {
        private IList<TDto> _list;
        private int offset;
        private int limit;

        public BootstrapTablePagedResult(int total, ICollection<TDto> rows)
        {
            Total = total;
            Rows = rows;
        }


        public BootstrapTablePagedResult(IList<TDto> list, int offset, int limit)
        {
            this._list = list;
            this.offset = offset;
            this.limit = limit == 0 ? 50 : limit;
            Init();
        }

        private void Init()
        {
            Total = _list.Count;
            Rows = _list.Skip(offset).Take(limit).ToList();
        }

        public int Total { get; private set; }

        public ICollection<TDto> Rows { get; private set; }
    }
}
