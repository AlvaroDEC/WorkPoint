using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Soluciones;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class SolucionService : ISolucionService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public SolucionService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CrearSolucion(CreateSolucionDto dto)
        {
            var solucion = _mapper.Map<Solucion>(dto);
            _context.Soluciones.Add(solucion);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SolucionDto>> ObtenerSoluciones()
        {
            var soluciones = await _context.Soluciones
                .Include(s => s.Observacion)
                .Include(s => s.Responsable)
                .Include(s => s.EvidenciasSolucion)
                .ToListAsync();

            return _mapper.Map<List<SolucionDto>>(soluciones);
        }

        public async Task<SolucionDto> ObtenerPorId(int id)
        {
            var solucion = await _context.Soluciones
                .Include(s => s.Observacion)
                .Include(s => s.Responsable)
                .Include(s => s.EvidenciasSolucion)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (solucion == null) throw new Exception("Solución no encontrada");

            return _mapper.Map<SolucionDto>(solucion);
        }

        public async Task ActualizarSolucion(UpdateSolucionDto dto)
        {
            var solucion = await _context.Soluciones.FindAsync(dto.Id);
            if (solucion == null)
                throw new Exception("Solución no encontrada");

            _mapper.Map(dto, solucion);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarSolucion(int id)
        {
            var solucion = await _context.Soluciones.FindAsync(id);
            if (solucion == null) throw new Exception("Solución no encontrada");

            _context.Soluciones.Remove(solucion);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SolucionDto>> ObtenerSolucionesPorObservacion(int observacionId)
        {
            var soluciones = await _context.Soluciones
                .Include(s => s.Observacion)
                .Include(s => s.Responsable)
                .Include(s => s.EvidenciasSolucion)
                .Where(s => s.ObservacionId == observacionId)
                .ToListAsync();

            return _mapper.Map<List<SolucionDto>>(soluciones);
        }

        public async Task<List<SolucionDto>> ObtenerSolucionesPorResponsable(int responsableId)
        {
            var soluciones = await _context.Soluciones
                .Include(s => s.Observacion)
                .Include(s => s.Responsable)
                .Include(s => s.EvidenciasSolucion)
                .Where(s => s.ResponsableId == responsableId)
                .ToListAsync();

            return _mapper.Map<List<SolucionDto>>(soluciones);
        }
    }
}
