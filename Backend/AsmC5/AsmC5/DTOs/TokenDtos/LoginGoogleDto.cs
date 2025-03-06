using System.ComponentModel.DataAnnotations;

namespace AsmC5.DTOs.TokenDtos
{
    public class LoginGoogleDto
    {
        [Required(ErrorMessage = "Credential không được để trống.")]
        public string Credential { get; set; }
    }
}
