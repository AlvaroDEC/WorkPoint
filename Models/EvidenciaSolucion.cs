using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Models
{
    public class EvidenciaSolucion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ArchivoBase64 { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoArchivo { get; set; } // "image/jpeg", "image/png", etc.

        public long TamañoBytes { get; set; }

        [Required]
        [ForeignKey(nameof(Solucion))]
        public int SolucionId { get; set; }
        public Solucion Solucion { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
