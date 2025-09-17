using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Acciones
{
    /// <summary>
    /// DTO para crear una nueva acción en el sistema
    /// </summary>
    public class CreateAccionDto
    {
        [Required(ErrorMessage = "El nombre de la acción es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get; set; }
    }
}
