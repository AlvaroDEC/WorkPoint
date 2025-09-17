using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        // Relaciones
        public ICollection<Observacion> Observaciones { get; set; }
    }
}
