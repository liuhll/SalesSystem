using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Services.Dtos;

namespace Jeuci.SalesSystem.Brands.Dtos
{
    [AutoMap(typeof(BrandInfo))]
    public class BrandInfoDto : EntityRequestInput<int>
    {
        public string BrandName { get; set; }

        public State State { get; set; }

        public IList<ServiceInfoDto> ServiceInfos { get; set; }

        private IDictionary<int, IList<ServiceInfoDto>> _serviceInfoDict;

        public IDictionary<int, IList<ServiceInfoDto>> ServiceInfoDict
        {
            get
            {
                _serviceInfoDict = new Dictionary<int, IList<ServiceInfoDto>>();
                int key = 1;
                var count = 0;
                ServiceInfoDto[] values =new ServiceInfoDto[SalesSystemConsts.LotterySeedRowNum];
                
                var rowMaxNum = ServiceInfos.Count / SalesSystemConsts.LotterySeedRowNum;
                bool isSurplus = ServiceInfos.Count % SalesSystemConsts.LotterySeedRowNum > 0;
                for (int i = 0; i < ServiceInfos.Count; i++)
                {
                    values[count] = ServiceInfos[i];
                    count++;
                    if ((i + 1) % SalesSystemConsts.LotterySeedRowNum == 0)
                    {
                        _serviceInfoDict[key] = values;
                        count = 0;
                        key++;
                        values = new ServiceInfoDto[SalesSystemConsts.LotterySeedRowNum];
                    }
                    if (isSurplus && key > rowMaxNum)
                    {
                        _serviceInfoDict[key] = values;
                    }
                }
                return _serviceInfoDict;
            }
        }

    }
}
