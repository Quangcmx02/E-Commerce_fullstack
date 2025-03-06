using System.ComponentModel.DataAnnotations;

namespace AsmC5.DTOs.AuthDtos
{
    public class SignUpDto
    {


        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required, MinLength(8), MaxLength(20), DataType(DataType.Password)]
        public string Password { get; set; } 
        [Required]
        public string DateOfBirth { get; set; }
        public List<string> Roles { get; set; } = new List<string> {
          
        };

        [Required]
        public string Email { get; set; } // Email từ IdentityUser

        public string PhoneNumber { get; set; } // Số điện thoại từ IdentityUser
    }
}
