using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Estados
{
    /// <summary>
    /// DTO para crear un nuevo estado en el sistema
    /// </summary>
    public class CreateEstadoDto
    {
        [Required(ErrorMessage = "El nombre del estado es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Descripcion { get; set; }
    }
}
