using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyPhoneBook.Authorization;

namespace MyPhoneBook
{
    [DependsOn(
        typeof(MyPhoneBookCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyPhoneBookApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyPhoneBookAuthorizationProvider>();
           

        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyPhoneBookApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
