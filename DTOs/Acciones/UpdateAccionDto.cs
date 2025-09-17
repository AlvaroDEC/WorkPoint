using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Acciones
{
    /// <summary>
    /// DTO para actualizar una acción existente
    /// </summary>
    public class UpdateAccionDto
    {
        [Required(ErrorMessage = "El ID de la acción es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la acción es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get; set; }
    }
}
