namespace ClaseEntityFramework.DTOs.Common
{
    /// <summary>
    /// Respuesta paginada estándar para reportes
    /// </summary>
    public class PagedResponse<T>
    {
        public bool Success { get; set; } = true;
        public List<T> Data { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
