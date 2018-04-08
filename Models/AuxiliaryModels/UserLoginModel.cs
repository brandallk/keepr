using System.ComponentModel.DataAnnotations;

namespace keepr.Models.AuxiliaryModels
{
    public class UserLoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}