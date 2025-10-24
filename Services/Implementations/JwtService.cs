using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Services.Implementations
{
    /// <summary>
    /// Implementación del servicio JWT para generación y validación de tokens
    /// </summary>
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Genera un token JWT para el usuario autenticado
        /// </summary>
        public string GenerarToken(Usuario usuario)
        {
            // Obtener configuración JWT
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

            // Crear claims (información del usuario en el token)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreCompleto ?? ""),
                new Claim(ClaimTypes.Email, usuario.Correo ?? ""),
                new Claim("RolId", usuario.RolId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Estado", usuario.Estado.ToString())
            };
            
            // Agregar rol si existe
            if (usuario.Rol != null && !string.IsNullOrEmpty(usuario.Rol.Nombre))
            {
                claims.Add(new Claim(ClaimTypes.Role, usuario.Rol.Nombre));
            }

            // Crear credenciales de firma
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            );

            // Crear el token
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: ObtenerFechaExpiracion(),
                signingCredentials: credentials
            );

            // Retornar el token como string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Obtiene la fecha de expiración configurada
        /// </summary>
        public DateTime ObtenerFechaExpiracion()
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var expiresInMinutes = int.Parse(jwtSettings["ExpiresInMinutes"]);
            return DateTime.UtcNow.AddMinutes(expiresInMinutes);
        }
    }
}

