namespace ClaseEntityFramework.DTOs.Asignaciones
{
    public class AsignacionDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public int AreaId { get; set; }
        public string AreaNombre { get; set; }
        public string RolEnArea { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public bool Activo { get; set; }
    }
}