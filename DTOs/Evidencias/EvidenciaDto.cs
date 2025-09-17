namespace ClaseEntityFramework.DTOs.Evidencias
{
    /// <summary>
    /// DTO para mostrar información de evidencia con Base64
    /// </summary>
    public class EvidenciaDto
    {
        public int Id { get; set; }
        public string ArchivoBase64 { get; set; }
        public string TipoArchivo { get; set; }
        public long TamañoBytes { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int ObservacionId { get; set; }
    }
}
