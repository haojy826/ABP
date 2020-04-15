using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyPhoneBook.Authorization.Roles;
using MyPhoneBook.Authorization.Users;
using MyPhoneBook.MultiTenancy;
using MyPhoneBook.Core.PhoneBooks.Persons;
using MyPhoneBook.Core.PhoneBooks.PhoneNumbers;

namespace MyPhoneBook.EntityFrameworkCore
{
    public class MyPhoneBookDbContext : AbpZeroDbContext<Tenant, Role, User, MyPhoneBookDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Person> Persons { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person", "PB");
            modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumber", "PB");
            base.OnModelCreating(modelBuilder);
        }
        public MyPhoneBookDbContext(DbContextOptions<MyPhoneBookDbContext> options)
            : base(options)
        {
        }
    }
}
