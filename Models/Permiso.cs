using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Models
{
    public class Permiso
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Rol))]
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        [Required]
        [ForeignKey(nameof(Accion))]
        public int AccionId { get; set; }
        public Accion Accion { get; set; }
    }
}
