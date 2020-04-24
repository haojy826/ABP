using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Web.Models;
using ABP.TPLMS.Entitys;
using ABP.TPLMS.Orgs.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABP.TPLMS.Orgs
{

    public class OrgAppService : AsyncCrudAppService<Org, OrgDto, int, PagedOrgResultRequestDto,
                            CreateUpdateOrgDto, CreateUpdateOrgDto>, IOrgAppService

    {
        public OrgAppService(IRepository<Org, int> repository)

            : base(repository)

        {

        }
        //重写GetAll方法，让ABP不要对数据进行包装
        [DontWrapResult]
        public override Task<PagedResultDto<OrgDto>> GetAllAsync(PagedOrgResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }
        //修改返回数据格式，为了能够适合前端的数据格式
        [DontWrapResult]
        public PagedOrgResultDto<OrgDto> GetAllOrgs(PagedOrgResultRequestDto input)
        {

            PagedOrgResultDto<OrgDto> orgs = new PagedOrgResultDto<OrgDto>();
            input.MaxResultCount = 1000;//这里可以修改为根据传递参数来决定数量
            var allOrgs = GetAllAsync(input);
            orgs.Rows = allOrgs.Result.Items;
            orgs.Total = allOrgs.Result.TotalCount;
            return orgs;
        }
    }
}