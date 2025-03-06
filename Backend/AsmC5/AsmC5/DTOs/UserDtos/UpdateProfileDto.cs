using System.ComponentModel.DataAnnotations;

namespace AsmC5.DTOs.UserDtos
{
    public class UpdateProfileDto
    {
   

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
 
        [Required]
        public string DateOfBirth { get; set; }
        public string? PhotoUrl { get; set; }

        public string? Adress { get; set; }
   
        public string PhoneNumber { get; set; } // Số điện thoại từ IdentityUser
    }
}
