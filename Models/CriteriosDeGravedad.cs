using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.Models
{
    public class CriterioDeGravedad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; } //  "PM", "MN", etc.

        [Required]
        public string Descripcion { get; set; }

        // Relaciones
        public ICollection<Observacion> Observaciones { get; set; }
    }
}
