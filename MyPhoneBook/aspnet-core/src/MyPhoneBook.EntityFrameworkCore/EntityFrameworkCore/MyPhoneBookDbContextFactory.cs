using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyPhoneBook.Configuration;
using MyPhoneBook.Web;

namespace MyPhoneBook.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyPhoneBookDbContextFactory : IDesignTimeDbContextFactory<MyPhoneBookDbContext>
    {
        public MyPhoneBookDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyPhoneBookDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyPhoneBookDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyPhoneBookConsts.ConnectionStringName));

            return new MyPhoneBookDbContext(builder.Options);
        }
    }
}
