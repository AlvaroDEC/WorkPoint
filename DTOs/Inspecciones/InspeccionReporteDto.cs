namespace ClaseEntityFramework.DTOs.Inspecciones
{
    /// <summary>
    /// DTO para reportes de inspecciones con todas las relaciones incluidas
    /// </summary>
    public class InspeccionReporteDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int AreaId { get; set; }
        public int AuditorId { get; set; }
        public string NombreArea { get; set; }
        public string NombreAuditor { get; set; }

        // Relaciones incluidas
        public AreaReporteDto Area { get; set; }
        public AuditorReporteDto Auditor { get; set; }
    }

    /// <summary>
    /// DTO para área en reportes
    /// </summary>
    public class AreaReporteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    /// <summary>
    /// DTO para auditor en reportes
    /// </summary>
    public class AuditorReporteDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
    }
}
