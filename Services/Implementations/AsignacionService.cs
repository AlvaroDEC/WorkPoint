using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Asignaciones;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class AsignacionService : IAsignacionService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public AsignacionService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CrearAsignacion(CreateAsignacionDto dto)
        {
            var asignacion = _mapper.Map<Asignacion>(dto);
            // Asegurar que siempre use UTC y esté activo
            asignacion.FechaAsignacion = DateTime.UtcNow;
            asignacion.Activo = true;
            _context.Asignaciones.Add(asignacion);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AsignacionDto>> ObtenerAsignaciones()
        {
            var asignaciones = await _context.Asignaciones
                .Include(a => a.Usuario)
                .Include(a => a.Area)
                .ToListAsync();

            return _mapper.Map<List<AsignacionDto>>(asignaciones);
        }

        public async Task<AsignacionDto> ObtenerPorId(int id)
        {
            var asignacion = await _context.Asignaciones
                .Include(a => a.Usuario)
                .Include(a => a.Area)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (asignacion == null) throw new Exception("Asignación no encontrada");

            return _mapper.Map<AsignacionDto>(asignacion);
        }

        public async Task ActualizarAsignacion(UpdateAsignacionDto dto)
        {
            var asignacion = await _context.Asignaciones.FindAsync(dto.Id);
            if (asignacion == null)
                throw new Exception("Asignación no encontrada");

            _mapper.Map(dto, asignacion);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsignacion(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null) throw new Exception("Asignación no encontrada");

            _context.Asignaciones.Remove(asignacion);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AsignacionDto>> ObtenerAsignacionesPorUsuario(int usuarioId)
        {
            var asignaciones = await _context.Asignaciones
                .Include(a => a.Usuario)
                .Include(a => a.Area)
                .Where(a => a.UsuarioId == usuarioId)
                .ToListAsync();

            return _mapper.Map<List<AsignacionDto>>(asignaciones);
        }

        public async Task<List<AsignacionDto>> ObtenerAsignacionesPorArea(int areaId)
        {
            var asignaciones = await _context.Asignaciones
                .Include(a => a.Usuario)
                .Include(a => a.Area)
                .Where(a => a.AreaId == areaId)
                .ToListAsync();

            return _mapper.Map<List<AsignacionDto>>(asignaciones);
        }
    }
}
