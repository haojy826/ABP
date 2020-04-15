using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyPhoneBook.EntityFrameworkCore
{
    public static class MyPhoneBookDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyPhoneBookDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyPhoneBookDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
