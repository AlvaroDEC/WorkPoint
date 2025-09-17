using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Asignaciones
{
    public class CreateAsignacionDto
    {
        [Required(ErrorMessage = "El ID del usuario es requerido")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El ID del área es requerido")]
        public int AreaId { get; set; }

        [Required(ErrorMessage = "El rol en el área es requerido")]
        [StringLength(20, ErrorMessage = "El rol no puede exceder 20 caracteres")]
        public string RolEnArea { get; set; }

        public bool Activo { get; set; } = true;
    }
}