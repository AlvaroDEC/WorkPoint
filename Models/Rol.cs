using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        // Relaciones
        public ICollection<AsignacionRoles> AsignacionesRoles { get; set; }
        public ICollection<Permiso> Permisos { get; set; }

    }
}