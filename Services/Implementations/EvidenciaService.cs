using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Evidencias;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class EvidenciaService : IEvidenciaService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public EvidenciaService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CrearEvidenciaAsync(CreateEvidenciaDto dto)
        {
            var evidencia = _mapper.Map<Evidencia>(dto);
            evidencia.FechaRegistro = DateTime.UtcNow;

            // Calcular el tamaño real del Base64 si no se proporciona
            if (evidencia.TamañoBytes == 0 && !string.IsNullOrEmpty(dto.ArchivoBase64))
            {
                var base64Data = dto.ArchivoBase64;
                if (base64Data.Contains(","))
                    base64Data = base64Data.Split(',')[1];

                evidencia.TamañoBytes = (long)(base64Data.Length * 0.75); // Base64 es ~33% más grande que los datos originales
            }

            _context.Evidencias.Add(evidencia);
            await _context.SaveChangesAsync();

            return evidencia.Id;
        }

        public async Task<EvidenciaDto?> ObtenerPorIdAsync(int id)
        {
            var evidencia = await _context.Evidencias
                .Include(e => e.Observacion)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evidencia == null)
                return null;

            return _mapper.Map<EvidenciaDto>(evidencia);
        }

        public async Task<List<EvidenciaDto>> ObtenerPorObservacionAsync(int observacionId)
        {
            var evidencias = await _context.Evidencias
                .Where(e => e.ObservacionId == observacionId)
                .OrderByDescending(e => e.FechaRegistro)
                .ToListAsync();

            return evidencias.Select(e => _mapper.Map<EvidenciaDto>(e)).ToList();
        }

        public async Task EliminarAsync(int id)
        {
            var evidencia = await _context.Evidencias.FindAsync(id);
            if (evidencia == null)
                throw new Exception("Evidencia no encontrada");

            _context.Evidencias.Remove(evidencia);
            await _context.SaveChangesAsync();
        }
    }
}
