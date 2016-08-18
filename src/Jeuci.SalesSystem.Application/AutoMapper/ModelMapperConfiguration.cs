using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Jeuci.SalesSystem.Domain.Sales.Models;
using Jeuci.SalesSystem.Sales.Dtos;

namespace Jeuci.SalesSystem.AutoMapper
{
    public static class ModelMapperConfiguration
    {
        public static void ConfigModelMapper()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<SalesInput, SalesInfoModel>();
            });
        }
    }
}
