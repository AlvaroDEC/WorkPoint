using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreCompleto { get; set; }

        [Required]
        [MaxLength(50)]
        public string Correo { get; set; }

        [Required] // revissar el tema de las contraseñas 

        public string Contraseña { get; set; }

        [Required]
        public bool Estado { get; set; } = true;

        // FK: Rol
        [ForeignKey(nameof(Rol))]
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        
        // Relaciones
        public ICollection<AsignacionRoles> AsignacionesRoles { get; set; }
        public ICollection<Asignacion> Asignaciones { get; set; }
        public ICollection<Inspeccion> Inspecciones { get; set; }
        public ICollection<Observacion> ObservacionesResponsable { get; set; }
        public ICollection<Seguimiento> Seguimientos { get; set; }
        public ICollection<Solucion> Soluciones { get; set; }
    }
}