using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Models
{
    public class Inspeccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "timestamp with time zone")]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } = "Programada";

        [Column(TypeName = "timestamp with time zone")]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

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