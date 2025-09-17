using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Models
{
    public class Asignacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        [ForeignKey(nameof(Area))]
        public int AreaId { get; set; }
        public Area Area { get; set; }

        [Required]
        [MaxLength(20)]
        public string RolEnArea { get; set; } // Inspector o Encargado

        public DateTime FechaAsignacion { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;
    }
}
