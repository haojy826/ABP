using System.Collections.Generic;
using MyPhoneBook.Roles.Dto;

namespace MyPhoneBook.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}