using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABP.TPLMS.Entitys;
using System;
using System.Collections.Generic;
using System.Text;


namespace ABP.TPLMS.Orgs.Dto
{

    [AutoMapFrom(typeof(Org))]
    public class OrgDto : EntityDto<int>
    {

        int m_parentId=0;
        public string Name { get; set; }

        public string HotKey { get; set; }
        public int ParentId { get { return m_parentId; } set { m_parentId = value; } }

        public string ParentName { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsAutoExpand { get; set; }

        public string IconName { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public string BizCode { get; set; }

        public string CustomCode { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public int CreateId { get; set; }
        public int SortNo { get; set; }
        //这里是关键，如果使用treegrid进行显示数据，那么根节点的这个属性必须为空，否则不显示
        public int? _parentId
        {
            get { 
                if(m_parentId==0)
                {
                    return null;
                }
                else
                {
                   return m_parentId;
                }
                }

        }
    }
}