using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.AsignacionRoles
{
    public class CreateAsignacionRolesDto
    {
        [Required(ErrorMessage = "El ID del usuario es requerido")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El ID del rol es requerido")]
        public int RolId { get; set; }

        public bool Activo { get; set; } = true;
    }
}
