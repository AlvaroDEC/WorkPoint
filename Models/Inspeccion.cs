using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Models
{
    public class Inspeccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; }  // "Programada", "Realizada"

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey(nameof(Area))]
        public int AreaId { get; set; }
        public Area Area { get; set; }

        [Required]
        [ForeignKey(nameof(Auditor))]
        public int AuditorId { get; set; }
        public Usuario Auditor { get; set; }

        // Relaciones
        public ICollection<Observacion> Observaciones { get; set; }

    }
}