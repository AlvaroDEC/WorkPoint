namespace ClaseEntityFramework.DTOs.Categorias
{
    /// <summary>
    /// DTO para reportes de categorías
    /// </summary>
    public class CategoriaReporteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
