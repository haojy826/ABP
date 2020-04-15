using System.Threading.Tasks;
using Abp.Application.Services;
using MyPhoneBook.Authorization.Accounts.Dto;

namespace MyPhoneBook.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
