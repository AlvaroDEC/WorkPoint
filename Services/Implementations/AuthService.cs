using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Auth;
using ClaseEntityFramework.DTOs.Usuarios;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public AuthService(AppContexts context, IMapper mapper, IJwtService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Correo == loginDto.Correo && u.Estado == true);

            if (usuario == null || !ValidatePasswordAsync(loginDto.Contraseña, usuario.Contraseña))
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Mensaje = "Credenciales inválidas"
                };
            }

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            usuarioDto.RolNombre = usuario.Rol?.Nombre;

            // Generar token JWT
            var token = _jwtService.GenerarToken(usuario);
            var expiresAt = _jwtService.ObtenerFechaExpiracion();

            return new LoginResponseDto
            {
                Success = true,
                Token = token,
                Usuario = usuarioDto,
                Mensaje = "Login exitoso",
                ExpiresAt = expiresAt
            };
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool ValidatePasswordAsync(string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                // Si el hash no es válido (por ejemplo, contraseña en texto plano), 
                // comparar directamente con la contraseña almacenada
                return password == hashedPassword;
            }
        }
    }
}
