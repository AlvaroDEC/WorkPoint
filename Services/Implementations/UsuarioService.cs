using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Usuarios;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public UsuarioService(AppContexts context, IMapper mapper, IAuthService authService)
        {
            _context = context;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<UsuarioDto> CrearUsuarioAsync(CreateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            usuario.Estado = true;
            
            // Hashear la contraseña antes de guardarla
            usuario.Contraseña = _authService.HashPassword(dto.Contraseña);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var rol = await _context.Roles.FindAsync(dto.RolId);

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            usuarioDto.RolNombre = rol?.Nombre;

            return usuarioDto;
        }
        public async Task<UsuarioDto> ActualizarParcialmenteUsuarioAsync(int id, UpdateUsuarioDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                return null;

            // Mapea sólo los campos presentes en dto sobre la entidad existente
            _mapper.Map(dto, usuario);
             
            if (dto.Estado.HasValue)
                usuario.Estado = dto.Estado.Value;

            await _context.SaveChangesAsync();

           var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            usuarioDto.RolNombre = (await _context.Roles.FindAsync(usuario.RolId))?.Nombre;

            return usuarioDto;
        }

        public async Task<List<UsuarioDto>> ObtenerUsuariosAsync()
        {
            var usuarios = await _context.Usuarios.Include(u => u.Rol).ToListAsync();
            return _mapper.Map<List<UsuarioDto>>(usuarios);
        }
        public async Task<UsuarioDto> ObtenerUsuarioPorIdAsync(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
                return null;

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return usuarioDto;
        }
    }
}
