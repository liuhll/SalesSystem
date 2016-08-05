using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Application.Dtos
{
    public class DefaultPagedResultRequest : IPagedResultRequest
    {
        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public DefaultPagedResultRequest()
        {
            MaxResultCount = 10;
        }
    }
}
