namespace ClaseEntityFramework.DTOs.Usuarios
{
    public class CreateUsuarioDto
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int RolId { get; set; }
    }
}