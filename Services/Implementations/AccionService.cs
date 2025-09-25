using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Acciones;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class AccionService : IAccionService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AccionService> _logger;

        public AccionService(AppContexts context, IMapper mapper, ILogger<AccionService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CrearAccion(CreateAccionDto dto)
        {
            try
            {
                _logger.LogInformation("Creando acción: {Nombre}", dto.Nombre);
                
                var accion = _mapper.Map<Accion>(dto);
                _context.Acciones.Add(accion);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Acción creada exitosamente con ID: {Id}", accion.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear acción: {Nombre}", dto.Nombre);
                throw;
            }
        }

        public async Task<List<AccionDto>> ObtenerAcciones()
        {
            try
            {
                _logger.LogDebug("Obteniendo todas las acciones");
                
                var acciones = await _context.Acciones.ToListAsync();
                var result = _mapper.Map<List<AccionDto>>(acciones);
                
                _logger.LogInformation("Acciones obtenidas: {Total}", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener acciones");
                throw;
            }
        }

        public async Task<AccionDto> ObtenerPorId(int id)
        {
            try
            {
                _logger.LogDebug("Obteniendo acción con ID: {Id}", id);
                
                var accion = await _context.Acciones.FindAsync(id);
                if (accion == null)
                {
                    _logger.LogWarning("Acción no encontrada con ID: {Id}", id);
                    throw new InvalidOperationException($"Acción con ID {id} no encontrada");
                }

                var result = _mapper.Map<AccionDto>(accion);
                _logger.LogDebug("Acción obtenida: {Nombre}", result.Nombre);
                
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener acción con ID: {Id}", id);
                throw;
            }
        }

        public async Task ActualizarAccion(UpdateAccionDto dto)
        {
            try
            {
                _logger.LogInformation("Actualizando acción con ID: {Id}", dto.Id);
                
                var accion = await _context.Acciones.FindAsync(dto.Id);
                if (accion == null)
                {
                    _logger.LogWarning("Acción no encontrada para actualizar con ID: {Id}", dto.Id);
                    throw new InvalidOperationException($"Acción con ID {dto.Id} no encontrada");
                }

                _mapper.Map(dto, accion);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Acción actualizada exitosamente: {Nombre}", accion.Nombre);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar acción con ID: {Id}", dto.Id);
                throw;
            }
        }

        public async Task EliminarAccion(int id)
        {
            try
            {
                _logger.LogInformation("Eliminando acción con ID: {Id}", id);
                
                var accion = await _context.Acciones.FindAsync(id);
                if (accion == null)
                {
                    _logger.LogWarning("Acción no encontrada para eliminar con ID: {Id}", id);
                    throw new InvalidOperationException($"Acción con ID {id} no encontrada");
                }

                _context.Acciones.Remove(accion);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Acción eliminada exitosamente: {Nombre}", accion.Nombre);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar acción con ID: {Id}", id);
                throw;
            }
        }

        public async Task EliminarTodasLasAcciones()
        {
            try
            {
                _logger.LogWarning("Eliminando TODAS las acciones del sistema");
                
                var acciones = await _context.Acciones.ToListAsync();
                var totalEliminadas = acciones.Count;
                
                _context.Acciones.RemoveRange(acciones);
                await _context.SaveChangesAsync();
                
                _logger.LogWarning("Todas las acciones eliminadas: {Total} acciones", totalEliminadas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar todas las acciones");
                throw;
            }
        }
    }
}
