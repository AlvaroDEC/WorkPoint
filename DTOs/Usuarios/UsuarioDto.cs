namespace ClaseEntityFramework.DTOs.Usuarios
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int RolId { get; set; }
        public string RolNombre { get; set; }
        public bool Estado { get; set; }
    }

}