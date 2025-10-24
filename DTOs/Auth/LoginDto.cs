using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La contraseña debe tener entre 1 y 100 caracteres")]
        public string Contraseña { get; set; }
    }
}
