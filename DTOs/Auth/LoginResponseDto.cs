using ClaseEntityFramework.DTOs.Usuarios;

namespace ClaseEntityFramework.DTOs.Auth
{
    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string Mensaje { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
