namespace ClaseEntityFramework.DTOs.Acciones
{
    /// <summary>
    /// DTO para mostrar información de una acción del sistema
    /// </summary>
    public class AccionDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TotalPermisos { get; set; }
    }
}
