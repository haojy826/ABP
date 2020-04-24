using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.TPLMS.Orgs.Dto
{
    //新创建的DTO，为了返回适合前端的数据格式
    public class PagedOrgResultDto<T>
    {
        public int Total
        {
            get;
            set;
        }
        public IReadOnlyList<T> Rows
        { get; set; }
    }
}
