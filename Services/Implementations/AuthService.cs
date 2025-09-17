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

        public AuthService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            return new LoginResponseDto
            {
                Success = true,
                Usuario = usuarioDto,
                Mensaje = "Login exitoso"
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
