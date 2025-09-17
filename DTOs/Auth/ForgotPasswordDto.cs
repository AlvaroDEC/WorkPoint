using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Auth
{
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; }
    }
}
