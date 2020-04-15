using System.Threading.Tasks;
using MyPhoneBook.Configuration.Dto;

namespace MyPhoneBook.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
