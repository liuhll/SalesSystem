using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Jeuci.SalesSystem.Entities.Common.Enums;

namespace Jeuci.SalesSystem.Sales.Dtos
{
    public class SalesInput : IInputDto
    {
        public int ServiceId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "请选择要购买的服务")]
        public int ServicePriceId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "请输入要购买服务的通行证(用户名|手机号)")]
        [RegularExpression("^[a-zA-Z0-9_]{3,16}$",ErrorMessage = "用户名不合法，请输入合法的用户名或是手机号")]
        public string Passport { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = "请输入售价")]
        [RegularExpression("^([0-9]+|[0-9]{1,3}(,[0-9]{3})*)(.[0-9]{1,2})?$",ErrorMessage = "您输入的值不正确，请输入正确的金额(数值)")] 
        public decimal Cost { get; set; }

        public string Remarks { get; set; }

    }
}
