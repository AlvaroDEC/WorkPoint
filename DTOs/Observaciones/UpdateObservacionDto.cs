using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Observaciones
{
    /// <summary>
    /// DTO para actualizar una observación existente
    /// </summary>
    public class UpdateObservacionDto
    {
        [Required(ErrorMessage = "El ID de la observación es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción de la observación es obligatoria")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 2000 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El ID del criterio de gravedad es obligatorio")]
        public int CriterioDeGravedadId { get; set; }

        [Required(ErrorMessage = "El ID de la categoría es obligatorio")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El ID del estado es obligatorio")]
        public int EstadoId { get; set; }


        [Required(ErrorMessage = "El ID del responsable es obligatorio")]
        public int ResponsableId { get; set; }
    }
}
