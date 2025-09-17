namespace ClaseEntityFramework.DTOs.Inspecciones
{
    public class InspeccionCompletaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreArea { get; set; }
        public string NombreAuditor { get; set; }
        public string Estado { get; set; }
        public List<ObservacionConEvidenciaDto> Observaciones { get; set; }
    }

    public class ObservacionConEvidenciaDto
    {
        public List<string> Evidencias { get; set; } 
        public string Descripcion { get; set; }
        public string Criterio { get; set; }
        public string Responsable { get; set; }
    }
}