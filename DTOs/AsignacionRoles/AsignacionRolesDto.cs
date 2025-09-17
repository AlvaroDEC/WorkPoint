namespace ClaseEntityFramework.DTOs.AsignacionRoles
{
    public class AsignacionRolesDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public int RolId { get; set; }
        public string RolNombre { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public bool Activo { get; set; }
    }
}
