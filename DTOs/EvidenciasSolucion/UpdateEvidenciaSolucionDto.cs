using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.EvidenciasSolucion
{
    /// <summary>
    /// DTO para actualizar una evidencia de solución existente con Base64
    /// </summary>
    public class UpdateEvidenciaSolucionDto
    {
        [Required(ErrorMessage = "El ID de la evidencia es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El archivo Base64 es obligatorio")]
        public string ArchivoBase64 { get; set; }

        [Required(ErrorMessage = "El tipo de archivo es obligatorio")]
        [StringLength(50, ErrorMessage = "El tipo de archivo no puede exceder 50 caracteres")]
        public string TipoArchivo { get; set; }
    }
}
