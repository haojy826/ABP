using System.Threading.Tasks;
using Abp.Application.Services;
using MyPhoneBook.Sessions.Dto;

namespace MyPhoneBook.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
