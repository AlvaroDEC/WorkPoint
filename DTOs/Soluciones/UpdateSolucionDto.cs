using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Soluciones
{
    public class UpdateSolucionDto
    {
        [Required(ErrorMessage = "El ID es requerido")]
        public int Id { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string? Descripcion { get; set; }

        public DateTime? FechaImplementacion { get; set; }
    }
}