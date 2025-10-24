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

        public async Task EliminarUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            // Verificar si el usuario tiene relaciones que impidan la eliminación
            var tieneInspecciones = await _context.Inspecciones.AnyAsync(i => i.AuditorId == id);
            var tieneObservaciones = await _context.Observaciones.AnyAsync(o => o.ResponsableId == id);
            var tieneSoluciones = await _context.Soluciones.AnyAsync(s => s.ResponsableId == id);
            var tieneSeguimientos = await _context.Seguimientos.AnyAsync(s => s.UsuarioId == id);

            if (tieneInspecciones || tieneObservaciones || tieneSoluciones || tieneSeguimientos)
            {
                // Soft delete: cambiar estado a false en lugar de eliminar físicamente
                usuario.Estado = false;
                await _context.SaveChangesAsync();
                throw new Exception("Usuario desactivado (soft delete) porque tiene relaciones. Para eliminación física, primero elimine las relaciones.");
            }
            else
            {
                // Hard delete: eliminar físicamente si no tiene relaciones
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        // ⚠️ MÉTODO PELIGROSO - Solo para testing
        public async Task EliminarUsuarioForzadoAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            // ⚠️ ELIMINACIÓN FORZADA - Puede romper relaciones
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
