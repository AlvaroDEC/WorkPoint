namespace ClaseEntityFramework.DTOs.Inspecciones
{
    public class InspeccionListaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreArea { get; set; }
        public string NombreAuditor { get; set; }
        public string Estado { get; set; }
    }
}
