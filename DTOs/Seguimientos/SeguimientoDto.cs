namespace ClaseEntityFramework.DTOs.Seguimientos
{
    /// <summary>
    /// DTO para mostrar información de un seguimiento de observación
    /// </summary>
    public class SeguimientoDto
    {
        public int Id { get; set; }
        public string Nota { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int ObservacionId { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
    }
}
