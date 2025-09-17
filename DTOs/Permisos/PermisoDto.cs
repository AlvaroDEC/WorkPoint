namespace ClaseEntityFramework.DTOs.Permisos
{
    /// <summary>
    /// DTO para mostrar información de un permiso (relación Rol-Acción)
    /// </summary>
    public class PermisoDto
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public string RolNombre { get; set; }
        public int AccionId { get; set; }
        public string AccionNombre { get; set; }
    }
}
