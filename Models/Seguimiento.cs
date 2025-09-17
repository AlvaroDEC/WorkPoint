using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Models
{
    public class Seguimiento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nota { get; set; }

        [Required]
        [ForeignKey(nameof(Observacion))]
        public int ObservacionId { get; set; }
        public Observacion Observacion { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
