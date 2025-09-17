using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.EvidenciasSolucion
{
    /// <summary>
    /// DTO para actualizar parcialmente una evidencia de solución con Base64
    /// </summary>
    public class PatchEvidenciaSolucionDto
    {
        public int? Id { get; set; }
        
        [StringLength(50, ErrorMessage = "El tipo de archivo no puede exceder 50 caracteres")]
        public string? TipoArchivo { get; set; }
        
        public string? ArchivoBase64 { get; set; }
    }
}
