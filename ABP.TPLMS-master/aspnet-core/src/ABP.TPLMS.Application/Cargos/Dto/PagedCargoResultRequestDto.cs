using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.TPLMS.Cargos.Dto
{
    public class PagedCargoResultRequestDto : PagedResultRequestDto
    {

        public string Keyword { get; set; }
        //下面三个方法是实现按条件查询
        public string CargoName { get; set; }
        public string CargoCode { get; set; }
        public string HsCode { get; set; }
    }
}