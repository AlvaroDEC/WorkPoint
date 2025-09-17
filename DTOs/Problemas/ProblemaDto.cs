namespace ClaseEntityFramework.DTOs.Problemas
{
    /// <summary>
    /// DTO para mostrar información completa de un problema
    /// </summary>
    public class ProblemaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int TotalObservaciones { get; set; }
        public int TotalSugerencias { get; set; }
    }
}
