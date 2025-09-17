using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.Models
{
    public class Accion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        // Relaciones
        public ICollection<Permiso> Permisos { get; set; }
    }
}
