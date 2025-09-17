using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Roles;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class RolService : IRolService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public RolService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CrearRol(CreateRolDto dto)
        {
            var rol = _mapper.Map<Rol>(dto);
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RolDto>> ObtenerRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return _mapper.Map<List<RolDto>>(roles);
        }

        public async Task<RolDto> ObtenerPorId(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null) throw new Exception("Rol no encontrado");

            return _mapper.Map<RolDto>(rol);
        }

        public async Task ActualizarRol(UpdateRolDto dto)
        {
            var rol = await _context.Roles.FindAsync(dto.Id);
            if (rol == null) throw new Exception("Rol no encontrado");

            _mapper.Map(dto, rol);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null) throw new Exception("Rol no encontrado");

            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
        }
    }
}
