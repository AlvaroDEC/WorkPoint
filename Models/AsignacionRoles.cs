using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Models
{
    public class AsignacionRoles
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        [ForeignKey(nameof(Rol))]
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        public DateTime FechaAsignacion { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;
    }
}
