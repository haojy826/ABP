using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyPhoneBook.Configuration;
using Abp.Configuration.Startup;

namespace MyPhoneBook.Web.Startup
{
    [DependsOn(typeof(MyPhoneBookWebCoreModule))]
    public class MyPhoneBookWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyPhoneBookWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<MyPhoneBookNavigationProvider>();
            Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true;//向前端返回完整错误日志
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyPhoneBookWebMvcModule).GetAssembly());
        }
    }
}
