using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Asignaciones
{
    public class UpdateAsignacionDto
    {
        [Required(ErrorMessage = "El ID es requerido")]
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "El rol no puede exceder 20 caracteres")]
        public string? RolEnArea { get; set; }

        public bool? Activo { get; set; }
    }
}