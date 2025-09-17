using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.AsignacionRoles;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class AsignacionRolesService : IAsignacionRolesService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public AsignacionRolesService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CrearAsignacionRoles(CreateAsignacionRolesDto dto)
        {
            var asignacionRoles = _mapper.Map<AsignacionRoles>(dto);
            _context.AsignacionesRoles.Add(asignacionRoles);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AsignacionRolesDto>> ObtenerAsignacionRoles()
        {
            var asignacionRoles = await _context.AsignacionesRoles
                .Include(ar => ar.Usuario)
                .Include(ar => ar.Rol)
                .ToListAsync();

            return _mapper.Map<List<AsignacionRolesDto>>(asignacionRoles);
        }

        public async Task<AsignacionRolesDto> ObtenerPorId(int id)
        {
            var asignacionRoles = await _context.AsignacionesRoles
                .Include(ar => ar.Usuario)
                .Include(ar => ar.Rol)
                .FirstOrDefaultAsync(ar => ar.Id == id);

            if (asignacionRoles == null) throw new Exception("Asignación de roles no encontrada");

            return _mapper.Map<AsignacionRolesDto>(asignacionRoles);
        }

        public async Task ActualizarAsignacionRoles(UpdateAsignacionRolesDto dto)
        {
            var asignacionRoles = await _context.AsignacionesRoles.FindAsync(dto.Id);
            if (asignacionRoles == null)
                throw new Exception("Asignación de roles no encontrada");

            _mapper.Map(dto, asignacionRoles);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsignacionRoles(int id)
        {
            var asignacionRoles = await _context.AsignacionesRoles.FindAsync(id);
            if (asignacionRoles == null) throw new Exception("Asignación de roles no encontrada");

            _context.AsignacionesRoles.Remove(asignacionRoles);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AsignacionRolesDto>> ObtenerAsignacionRolesPorUsuario(int usuarioId)
        {
            var asignacionRoles = await _context.AsignacionesRoles
                .Include(ar => ar.Usuario)
                .Include(ar => ar.Rol)
                .Where(ar => ar.UsuarioId == usuarioId)
                .ToListAsync();

            return _mapper.Map<List<AsignacionRolesDto>>(asignacionRoles);
        }

        public async Task<List<AsignacionRolesDto>> ObtenerAsignacionRolesPorRol(int rolId)
        {
            var asignacionRoles = await _context.AsignacionesRoles
                .Include(ar => ar.Usuario)
                .Include(ar => ar.Rol)
                .Where(ar => ar.RolId == rolId)
                .ToListAsync();

            return _mapper.Map<List<AsignacionRolesDto>>(asignacionRoles);
        }
    }
}
