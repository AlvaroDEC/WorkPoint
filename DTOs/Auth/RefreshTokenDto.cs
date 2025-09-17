using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Auth
{
    public class RefreshTokenDto
    {
        [Required(ErrorMessage = "El refresh token es requerido")]
        public string RefreshToken { get; set; }
    }
}
