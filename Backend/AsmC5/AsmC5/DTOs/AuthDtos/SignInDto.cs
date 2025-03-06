using System.ComponentModel.DataAnnotations;

namespace AsmC5.DTOs.AuthDtos
{
    public class SignInDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } 
        [Required, MinLength(8), MaxLength(20), DataType(DataType.Password)]
        public string Password { get; set; } 
        public bool IsRemember { get; set; }
    }
}
