using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Models
{
    public class Solucion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [ForeignKey(nameof(Observacion))]
        public int ObservacionId { get; set; }
        public Observacion Observacion { get; set; }

        [Required]
        [ForeignKey(nameof(Responsable))]
        public int ResponsableId { get; set; }
        public Usuario Responsable { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaImplementacion { get; set; }

        // Relaciones
        public ICollection<EvidenciaSolucion> EvidenciasSolucion { get; set; }
    }
}
