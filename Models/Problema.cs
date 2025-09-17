using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.Models
{
    public class Problema
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(20)]
        public string Codigo { get; set; }

        // Relaciones
        public ICollection<Observacion> Observaciones { get; set; }
        public ICollection<Sugerencia> Sugerencias { get; set; }
    }
}
