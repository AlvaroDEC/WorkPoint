using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Soluciones
{
    public class CreateSolucionDto
    {
        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El ID de la observación es requerido")]
        public int ObservacionId { get; set; }

        [Required(ErrorMessage = "El ID del responsable es requerido")]
        public int ResponsableId { get; set; }

        public DateTime? FechaImplementacion { get; set; }
    }
}