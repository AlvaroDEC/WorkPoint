using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Categorias
{
    /// <summary>
    /// DTO para crear una nueva categoría de observación
    /// </summary>
    public class CreateCategoriaDto
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Descripcion { get; set; }
    }
}
