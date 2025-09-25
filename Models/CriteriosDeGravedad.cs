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

        public int Nivel { get; set; } = 1;

        public string Color { get; set; } = "#000000";

        // Relaciones
        public ICollection<Observacion> Observaciones { get; set; }
    }
}
