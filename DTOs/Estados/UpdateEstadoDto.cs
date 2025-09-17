using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Estados
{
    /// <summary>
    /// DTO para actualizar un estado existente
    /// </summary>
    public class UpdateEstadoDto
    {
        [Required(ErrorMessage = "El ID del estado es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del estado es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Descripcion { get; set; }
    }
}
