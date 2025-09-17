using System.ComponentModel.DataAnnotations;

namespace ClaseEntityFramework.DTOs.EvidenciasSolucion
{
    public class CreateEvidenciaSolucionDto
    {
        [Required(ErrorMessage = "El archivo Base64 es requerido")]
        public string ArchivoBase64 { get; set; }

        [Required(ErrorMessage = "El tipo de archivo es requerido")]
        [StringLength(50, ErrorMessage = "El tipo de archivo no puede exceder 50 caracteres")]
        public string TipoArchivo { get; set; }

        [Required(ErrorMessage = "El tamaño en bytes es requerido")]
        [Range(1, long.MaxValue, ErrorMessage = "El tamaño debe ser mayor a 0")]
        public long TamañoBytes { get; set; }

        [Required(ErrorMessage = "El ID de la solución es requerido")]
        public int SolucionId { get; set; }
    }
}