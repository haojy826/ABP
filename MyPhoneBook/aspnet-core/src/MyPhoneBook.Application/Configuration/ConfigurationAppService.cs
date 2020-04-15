using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyPhoneBook.Configuration.Dto;

namespace MyPhoneBook.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyPhoneBookAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
