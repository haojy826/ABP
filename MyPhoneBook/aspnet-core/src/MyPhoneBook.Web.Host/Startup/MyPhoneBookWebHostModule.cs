using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyPhoneBook.Configuration;

namespace MyPhoneBook.Web.Host.Startup
{
    [DependsOn(
       typeof(MyPhoneBookWebCoreModule))]
    public class MyPhoneBookWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyPhoneBookWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyPhoneBookWebHostModule).GetAssembly());
        }
    }
}
