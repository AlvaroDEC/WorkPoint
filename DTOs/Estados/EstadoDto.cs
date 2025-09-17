namespace ClaseEntityFramework.DTOs.Estados
{
    /// <summary>
    /// DTO para mostrar información de un estado de observación
    /// </summary>
    public class EstadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TotalObservaciones { get; set; }
    }
}
