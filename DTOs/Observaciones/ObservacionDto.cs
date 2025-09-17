namespace ClaseEntityFramework.DTOs.Observaciones
{
    /// <summary>
    /// DTO para mostrar información completa de una observación
    /// </summary>
    public class ObservacionDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        
        // Información del criterio de gravedad
        public int CriterioDeGravedadId { get; set; }
        public string CriterioCodigo { get; set; }
        public string CriterioDescripcion { get; set; }
        
        // Información de la categoría
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        
        // Información del estado
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
        
        // Información del problema
        public int ProblemaId { get; set; }
        public string ProblemaNombre { get; set; }
        public string ProblemaCodigo { get; set; }
        
        // Información de la inspección
        public int InspeccionId { get; set; }
        public DateTime InspeccionFecha { get; set; }
        public string InspeccionAreaNombre { get; set; }
        
        // Información del responsable
        public int ResponsableId { get; set; }
        public string ResponsableNombre { get; set; }
        
        // Contadores
        public int TotalEvidencias { get; set; }
        public int TotalSoluciones { get; set; }
        public int TotalSeguimientos { get; set; }
    }
}
