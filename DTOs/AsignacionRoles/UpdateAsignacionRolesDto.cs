using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.AsignacionRoles
{
    public class UpdateAsignacionRolesDto
    {
        [Required(ErrorMessage = "El ID es requerido")]
        public int Id { get; set; }

        public bool? Activo { get; set; }
    }
}
