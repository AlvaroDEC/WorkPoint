using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Models
{
    /// <summary>
    /// Modelo para evidencias de observaciones usando Base64
    /// </summary>
    public class Evidencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ArchivoBase64 { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoArchivo { get; set; } // "image/jpeg", "image/png", etc.

        public long TamañoBytes { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // FK: Observación
        [Required]
        [ForeignKey(nameof(Observacion))]
        public int ObservacionId { get; set; }
        public Observacion Observacion { get; set; }
    }
}