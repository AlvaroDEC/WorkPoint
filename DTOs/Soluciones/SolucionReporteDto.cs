namespace ClaseEntityFramework.DTOs.Soluciones
{
    /// <summary>
    /// DTO para reportes de soluciones con todas las relaciones incluidas
    /// </summary>
    public class SolucionReporteDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int ObservacionId { get; set; }
        public int ResponsableId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaImplementacion { get; set; }
        public int TotalEvidencias { get; set; }

        // Relaciones incluidas
        public ObservacionReporteSimpleDto Observacion { get; set; }
        public ResponsableReporteDto Responsable { get; set; }
    }

    /// <summary>
    /// DTO simplificado para observación en reportes de soluciones
    /// </summary>
    public class ObservacionReporteSimpleDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    /// <summary>
    /// DTO para responsable en reportes (reutilizado de observaciones)
    /// </summary>
    public class ResponsableReporteDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
    }
}
