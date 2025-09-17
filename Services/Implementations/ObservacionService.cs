using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Observaciones;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class ObservacionService : IObservacionService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public ObservacionService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task ActualizarParcialAsync(PatchObservacionDto dto)
        {
            var observacion = await _context.Observaciones.FindAsync(dto.Id);
            if (observacion == null)
                throw new Exception("Observación no encontrada");

            // Usar AutoMapper para campos simples
            _mapper.Map(dto, observacion);

            // Lógica específica para el estado (por nombre)
            if (!string.IsNullOrWhiteSpace(dto.Estado))
            {
                var estado = await _context.Estados.FirstOrDefaultAsync(e => e.Nombre == dto.Estado);
                if (estado != null)
                    observacion.EstadoId = estado.Id;
            }

            await _context.SaveChangesAsync();
        }
    }
}