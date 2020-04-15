using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyPhoneBook.MultiTenancy.Dto;

namespace MyPhoneBook.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

