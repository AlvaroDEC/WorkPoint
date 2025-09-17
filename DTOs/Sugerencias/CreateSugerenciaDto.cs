using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Sugerencias
{
    public class CreateSugerenciaDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El código es requerido")]
        [StringLength(20, ErrorMessage = "El código no puede exceder 20 caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El ID del problema es requerido")]
        public int ProblemaId { get; set; }
    }
}