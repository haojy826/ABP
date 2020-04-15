using System.Collections.Generic;
using MyPhoneBook.Roles.Dto;
using MyPhoneBook.Users.Dto;

namespace MyPhoneBook.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
