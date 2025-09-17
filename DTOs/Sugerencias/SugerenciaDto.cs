namespace ClaseEntityFramework.DTOs.Sugerencias
{
    public class SugerenciaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int ProblemaId { get; set; }
        public string ProblemaNombre { get; set; }
        public string ProblemaCodigo { get; set; }
    }
}