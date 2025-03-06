using System.ComponentModel.DataAnnotations;
namespace AsmC5.DTOs.UserDtos
{
    public class UserDto
    {
        public string Id { get; set; } // ID từ IdentityUser

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        public string? PhotoUrl { get; set; }

        public string? Adress { get; set; }
        [Required]
        public string Email { get; set; } // Email từ IdentityUser
        public int TotalCartProducts { get; set; }
        public string PhoneNumber { get; set; } // Số điện thoại từ IdentityUser
        public ICollection<string> Roles { get; set; } = new List<string>();

    }
}
