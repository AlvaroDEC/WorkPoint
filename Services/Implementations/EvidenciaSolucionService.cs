using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.EvidenciasSolucion;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class EvidenciaSolucionService : IEvidenciaSolucionService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public EvidenciaSolucionService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CrearEvidenciaSolucion(CreateEvidenciaSolucionDto dto)
        {
            var evidenciaSolucion = _mapper.Map<EvidenciaSolucion>(dto);
            _context.EvidenciasSolucion.Add(evidenciaSolucion);
            await _context.SaveChangesAsync();
        }

        public async Task<EvidenciaSolucionDto> ObtenerPorId(int id)
        {
            var evidenciaSolucion = await _context.EvidenciasSolucion
                .Include(es => es.Solucion)
                .FirstOrDefaultAsync(es => es.Id == id);

            if (evidenciaSolucion == null) throw new Exception("Evidencia de solución no encontrada");

            return _mapper.Map<EvidenciaSolucionDto>(evidenciaSolucion);
        }

        public async Task EliminarEvidenciaSolucion(int id)
        {
            var evidenciaSolucion = await _context.EvidenciasSolucion.FindAsync(id);
            if (evidenciaSolucion == null) throw new Exception("Evidencia de solución no encontrada");

            _context.EvidenciasSolucion.Remove(evidenciaSolucion);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EvidenciaSolucionDto>> ObtenerEvidenciasPorSolucion(int solucionId)
        {
            var evidenciasSolucion = await _context.EvidenciasSolucion
                .Include(es => es.Solucion)
                .Where(es => es.SolucionId == solucionId)
                .ToListAsync();

            return _mapper.Map<List<EvidenciaSolucionDto>>(evidenciasSolucion);
        }
    }
}
