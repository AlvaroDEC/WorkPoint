using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.Models
{
    public class Area
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(20)]
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public bool Estado { get; set; } = true;

        // Relaciones
        public ICollection<Inspeccion> Inspecciones { get; set; }
        public ICollection<Asignacion> Asignaciones { get; set; }

    }
}