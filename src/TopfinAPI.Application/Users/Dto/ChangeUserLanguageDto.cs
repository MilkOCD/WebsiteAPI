using System.ComponentModel.DataAnnotations;

namespace TopfinAPI.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}