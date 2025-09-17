using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Sugerencias;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class SugerenciaService : ISugerenciaService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public SugerenciaService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CrearSugerencia(CreateSugerenciaDto dto)
        {
            var sugerencia = _mapper.Map<Sugerencia>(dto);
            _context.Sugerencias.Add(sugerencia);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SugerenciaDto>> ObtenerSugerencias()
        {
            var sugerencias = await _context.Sugerencias
                .Include(s => s.Problema)
                .ToListAsync();

            return _mapper.Map<List<SugerenciaDto>>(sugerencias);
        }

        public async Task<SugerenciaDto> ObtenerPorId(int id)
        {
            var sugerencia = await _context.Sugerencias
                .Include(s => s.Problema)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sugerencia == null) throw new Exception("Sugerencia no encontrada");

            return _mapper.Map<SugerenciaDto>(sugerencia);
        }

        public async Task ActualizarSugerencia(UpdateSugerenciaDto dto)
        {
            var sugerencia = await _context.Sugerencias.FindAsync(dto.Id);
            if (sugerencia == null)
                throw new Exception("Sugerencia no encontrada");

            _mapper.Map(dto, sugerencia);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarSugerencia(int id)
        {
            var sugerencia = await _context.Sugerencias.FindAsync(id);
            if (sugerencia == null) throw new Exception("Sugerencia no encontrada");

            _context.Sugerencias.Remove(sugerencia);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SugerenciaDto>> ObtenerSugerenciasPorProblema(int problemaId)
        {
            var sugerencias = await _context.Sugerencias
                .Include(s => s.Problema)
                .Where(s => s.ProblemaId == problemaId)
                .ToListAsync();

            return _mapper.Map<List<SugerenciaDto>>(sugerencias);
        }
    }
}
