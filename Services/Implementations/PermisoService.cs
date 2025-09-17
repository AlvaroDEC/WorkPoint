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
    }
}
