using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Auth
{
    public class ResetPasswordDto
    {
        [Required(ErrorMessage = "El token de reseteo es requerido")]
        public string Token { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La nueva contraseña es requerida")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La nueva contraseña debe tener entre 6 y 100 caracteres")]
        public string NuevaContraseña { get; set; }

        [Required(ErrorMessage = "La confirmación de contraseña es requerida")]
        [Compare("NuevaContraseña", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarContraseña { get; set; }
    }
}
