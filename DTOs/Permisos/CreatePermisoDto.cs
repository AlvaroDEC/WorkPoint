using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Permisos
{
    public class CreatePermisoDto
    {
        [Required(ErrorMessage = "El ID del rol es requerido")]
        public int RolId { get; set; }

        [Required(ErrorMessage = "El ID de la acción es requerido")]
        public int AccionId { get; set; }
    }
}