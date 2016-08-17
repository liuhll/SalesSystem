using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Jeuci.SalesSystem.Brands.Dtos;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common.Enums;

namespace Jeuci.SalesSystem.SoftServices.Dtos
{
    [AutoMap(typeof(ServiceInfo))]
    public class ServiceInfoDto : EntityRequestInput<int>
    {
        public string ServiceName { get; set; }

        public int BrandId { get; set; }

        public BrandInfoDto BrandInfo { get; set; }

        public State State { get; protected set; }

        public string Remarks { get; set; }

        public int Sort { get; set; }

        public virtual IList<ServicePriceDto> ServicePrices { get; set; }

        private IDictionary<int, IList<ServicePriceDto>> _servicePricesDict;

        public virtual IDictionary<int, IList<ServicePriceDto>> ServicePricesDict
        {
            get
            {
                _servicePricesDict = new Dictionary<int, IList<ServicePriceDto>>();
                int key = 1;
                var count = 0;
                ServicePriceDto[] values = new ServicePriceDto[SalesSystemConsts.LotteryServerPriceRowNum];

                var rowMaxNum = ServicePrices.Count / SalesSystemConsts.LotteryServerPriceRowNum;
                bool isSurplus = ServicePrices.Count % SalesSystemConsts.LotteryServerPriceRowNum > 0;
                for (int i = 0; i < ServicePrices.Count; i++)
                {
                    values[count] = ServicePrices[i];
                    count++;
                    if ((i + 1) % SalesSystemConsts.LotteryServerPriceRowNum == 0)
                    {
                        _servicePricesDict[key] = values;
                        count = 0;
                        key++;
                        values = new ServicePriceDto[SalesSystemConsts.LotteryServerPriceRowNum];
                    }
                    if (isSurplus && key > rowMaxNum)
                    {
                        _servicePricesDict[key] = values;
                    }
               
                }
                return _servicePricesDict;
            }
        }
    }
}
