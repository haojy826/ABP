using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyPhoneBook.MultiTenancy;

namespace MyPhoneBook.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
