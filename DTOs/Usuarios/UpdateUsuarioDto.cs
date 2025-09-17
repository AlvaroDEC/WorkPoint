 namespace ClaseEntityFramework.DTOs.Usuarios
 {
    public class UpdateUsuarioDto
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? RolId { get; set; }
        public bool? Estado { get; set; }
    }
 }