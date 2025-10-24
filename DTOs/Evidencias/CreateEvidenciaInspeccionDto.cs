using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.Evidencias
{
    /// <summary>
    /// DTO para crear evidencia desde inspección (sin ObservacionId)
    /// </summary>
    public class CreateEvidenciaInspeccionDto
    {
        [Required(ErrorMessage = "El archivo Base64 es obligatorio")]
        public string ArchivoBase64 { get; set; }

        [Required(ErrorMessage = "El tipo de archivo es obligatorio")]
        [StringLength(50, ErrorMessage = "El tipo de archivo no puede exceder 50 caracteres")]
        public string TipoArchivo { get; set; }

        public long TamañoBytes { get; set; }
    }
}
