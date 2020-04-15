using System.ComponentModel.DataAnnotations;

namespace MyPhoneBook.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}