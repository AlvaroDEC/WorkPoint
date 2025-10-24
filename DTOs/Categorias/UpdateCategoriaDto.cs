using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Categorias
{
    /// <summary>
    /// DTO para actualizar una categoría existente
    /// </summary>
    public class UpdateCategoriaDto
    {
        [Required(ErrorMessage = "El ID de la categoría es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Descripcion { get; set; }

        public bool Activo { get; set; }
    }
}
