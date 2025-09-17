using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Problemas
{
    /// <summary>
    /// DTO para crear un nuevo problema en el sistema
    /// </summary>
    public class CreateProblemaDto
    {
        [Required(ErrorMessage = "El nombre del problema es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El código del problema es obligatorio")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El código debe tener entre 2 y 20 caracteres")]
        public string Codigo { get; set; }
    }
}
