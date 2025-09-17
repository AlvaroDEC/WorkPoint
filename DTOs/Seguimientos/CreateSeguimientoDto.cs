using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Seguimientos
{
    public class CreateSeguimientoDto
    {
        [Required(ErrorMessage = "La nota es requerida")]
        [StringLength(500, ErrorMessage = "La nota no puede exceder 500 caracteres")]
        public string Nota { get; set; }

        [Required(ErrorMessage = "El ID de la observación es requerido")]
        public int ObservacionId { get; set; }

        [Required(ErrorMessage = "El ID del usuario es requerido")]
        public int UsuarioId { get; set; }
    }
}