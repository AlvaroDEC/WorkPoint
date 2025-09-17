using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Sugerencias
{
    public class UpdateSugerenciaDto
    {
        [Required(ErrorMessage = "El ID es requerido")]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string? Nombre { get; set; }

        [StringLength(20, ErrorMessage = "El código no puede exceder 20 caracteres")]
        public string? Codigo { get; set; }
    }
}