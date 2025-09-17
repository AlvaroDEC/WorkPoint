using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Inspecciones
{
    /// <summary>
    /// DTO para actualizar una inspección existente
    /// </summary>
    public class UpdateInspeccionDto
    {
        [Required(ErrorMessage = "El ID de la inspección es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de la inspección es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El estado de la inspección es obligatorio")]
        [StringLength(50, ErrorMessage = "El estado no puede exceder 50 caracteres")]
        public string Estado { get; set; } // "Programada", "Realizada"

        [Required(ErrorMessage = "El ID del área es obligatorio")]
        public int AreaId { get; set; }

        [Required(ErrorMessage = "El ID del auditor es obligatorio")]
        public int AuditorId { get; set; }
    }
}
