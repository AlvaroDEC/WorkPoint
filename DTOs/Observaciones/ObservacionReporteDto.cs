namespace ClaseEntityFramework.DTOs.Observaciones
{
    /// <summary>
    /// DTO para reportes de observaciones con todas las relaciones incluidas
    /// </summary>
    public class ObservacionReporteDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int InspeccionId { get; set; }
        public int CriterioDeGravedadId { get; set; }
        public int CategoriaId { get; set; }
        public int EstadoId { get; set; }
        public int ResponsableId { get; set; }

        // Relaciones incluidas
        public CriterioDeGravedadReporteDto CriterioDeGravedad { get; set; }
        public CategoriaObservacionReporteDto Categoria { get; set; }
        public EstadoObservacionReporteDto Estado { get; set; }
        public ResponsableReporteDto Responsable { get; set; }
    }

    /// <summary>
    /// DTO para criterio de gravedad en reportes
    /// </summary>
    public class CriterioDeGravedadReporteDto
    {
        public int Id { get; set; }
        public int Nivel { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
    }

    /// <summary>
    /// DTO para categoría en reportes de observaciones
    /// </summary>
    public class CategoriaObservacionReporteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    /// <summary>
    /// DTO para estado en reportes de observaciones
    /// </summary>
    public class EstadoObservacionReporteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }


    /// <summary>
    /// DTO para responsable en reportes
    /// </summary>
    public class ResponsableReporteDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
    }
}
