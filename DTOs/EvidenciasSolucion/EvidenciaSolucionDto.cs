namespace ClaseEntityFramework.DTOs.EvidenciasSolucion
{
    public class EvidenciaSolucionDto
    {
        public int Id { get; set; }
        public string ArchivoBase64 { get; set; }
        public string TipoArchivo { get; set; }
        public long TamañoBytes { get; set; }
        public int SolucionId { get; set; }
        public string SolucionDescripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}