namespace ClaseEntityFramework.DTOs.Observaciones
{
    /// <summary>
    /// DTO para mostrar observaciones en listados (información resumida)
    /// </summary>
    public class ObservacionListaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        
        // Información básica
        public string CriterioCodigo { get; set; }
        public string CategoriaNombre { get; set; }
        public string EstadoNombre { get; set; }
        
        // Información del responsable
        public string ResponsableNombre { get; set; }
        
        // Información de la inspección
        public string InspeccionAreaNombre { get; set; }
        public DateTime InspeccionFecha { get; set; }
        
        // Contadores
        public int TotalEvidencias { get; set; }
        public int TotalSoluciones { get; set; }
        public int TotalSeguimientos { get; set; }
    }
}
