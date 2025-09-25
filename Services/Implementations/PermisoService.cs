using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Permisos;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class PermisoService : IPermisoService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public PermisoService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CrearPermiso(CreatePermisoDto dto)
        {
            var permiso = _mapper.Map<Permiso>(dto);
            _context.Permisos.Add(permiso);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PermisoDto>> ObtenerPermisosPorRol(int rolId)
        {
            var permisos = await _context.Permisos
                .Include(p => p.Rol)
                .Include(p => p.Accion)
                .Where(p => p.RolId == rolId)
                .ToListAsync();

            return permisos.Select(p => new PermisoDto
            {
                Id = p.Id,
                RolId = p.RolId,
                RolNombre = p.Rol.Nombre,
                AccionId = p.AccionId,
                AccionNombre = p.Accion.Nombre
            }).ToList();
        }

        public async Task AsignarPermisosARol(int rolId, List<int> accionIds)
        {
            // Eliminar permisos existentes del rol
            var permisosExistentes = await _context.Permisos
                .Where(p => p.RolId == rolId)
                .ToListAsync();
            
            _context.Permisos.RemoveRange(permisosExistentes);

            // Agregar nuevos permisos
            foreach (var accionId in accionIds)
            {
                var permiso = new Permiso
                {
                    RolId = rolId,
                    AccionId = accionId
                };
                _context.Permisos.Add(permiso);
            }

            await _context.SaveChangesAsync();
        }

        public async Task EliminarPermiso(int rolId, int accionId)
        {
            var permiso = await _context.Permisos
                .FirstOrDefaultAsync(p => p.RolId == rolId && p.AccionId == accionId);
            
            if (permiso != null)
            {
                _context.Permisos.Remove(permiso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
