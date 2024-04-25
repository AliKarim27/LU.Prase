using System.ComponentModel.DataAnnotations;

namespace LU.Prase.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}