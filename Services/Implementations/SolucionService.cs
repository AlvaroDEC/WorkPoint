using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Soluciones;
using ClaseEntityFramework.DTOs.Common;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    /// <summary>
    /// Servicio para gestionar soluciones del sistema BPM
    /// </summary>
    public class SolucionService : ISolucionService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public SolucionService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Crear una nueva solución
        /// </summary>
        public async Task CrearSolucion(CreateSolucionDto dto)
        {
            var solucion = _mapper.Map<Solucion>(dto);
            _context.Soluciones.Add(solucion);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Obtener todas las soluciones con relaciones incluidas
        /// </summary>
        public async Task<List<SolucionDto>> ObtenerSoluciones()
        {
            var soluciones = await ObtenerQueryConRelaciones().ToListAsync();
            return _mapper.Map<List<SolucionDto>>(soluciones);
        }

        /// <summary>
        /// Obtener solución por ID
        /// </summary>
        public async Task<SolucionDto> ObtenerPorId(int id)
        {
            var solucion = await ObtenerQueryConRelaciones()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (solucion == null) 
                throw new ArgumentException("Solución no encontrada", nameof(id));

            return _mapper.Map<SolucionDto>(solucion);
        }

        /// <summary>
        /// Actualizar una solución existente
        /// </summary>
        public async Task ActualizarSolucion(UpdateSolucionDto dto)
        {
            var solucion = await _context.Soluciones.FindAsync(dto.Id);
            if (solucion == null)
                throw new ArgumentException("Solución no encontrada", nameof(dto.Id));

            _mapper.Map(dto, solucion);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Eliminar una solución
        /// </summary>
        public async Task EliminarSolucion(int id)
        {
            var solucion = await _context.Soluciones.FindAsync(id);
            if (solucion == null) 
                throw new ArgumentException("Solución no encontrada", nameof(id));

            _context.Soluciones.Remove(solucion);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Obtener soluciones por observación
        /// </summary>
        public async Task<List<SolucionDto>> ObtenerSolucionesPorObservacion(int observacionId)
        {
            var soluciones = await ObtenerQueryConRelaciones()
                .Where(s => s.ObservacionId == observacionId)
                .ToListAsync();

            return _mapper.Map<List<SolucionDto>>(soluciones);
        }

        /// <summary>
        /// Obtener soluciones por responsable
        /// </summary>
        public async Task<List<SolucionDto>> ObtenerSolucionesPorResponsable(int responsableId)
        {
            var soluciones = await ObtenerQueryConRelaciones()
                .Where(s => s.ResponsableId == responsableId)
                .ToListAsync();

            return _mapper.Map<List<SolucionDto>>(soluciones);
        }

        /// <summary>
        /// Query base con todas las relaciones incluidas para evitar duplicación
        /// </summary>
        private IQueryable<Solucion> ObtenerQueryConRelaciones()
        {
            return _context.Soluciones
                .Include(s => s.Observacion)
                .Include(s => s.Responsable)
                .Include(s => s.EvidenciasSolucion);
        }

        /// <summary>
        /// Obtener soluciones para reportes con filtros por fecha
        /// </summary>
        public async Task<PagedResponse<SolucionReporteDto>> ObtenerParaReportesAsync(string? fechaDesde, string? fechaHasta, int pageSize)
        {
            var query = _context.Soluciones
                .Include(s => s.Observacion)
                .Include(s => s.Responsable)
                .Include(s => s.EvidenciasSolucion)
                .AsQueryable();

            // Aplicar filtros de fecha
            if (!string.IsNullOrEmpty(fechaDesde) && DateTime.TryParse(fechaDesde, out var fechaInicio))
            {
                query = query.Where(s => s.FechaCreacion >= fechaInicio);
            }

            if (!string.IsNullOrEmpty(fechaHasta) && DateTime.TryParse(fechaHasta, out var fechaFin))
            {
                query = query.Where(s => s.FechaCreacion <= fechaFin.AddDays(1).AddTicks(-1));
            }

            // Obtener total de registros
            var totalCount = await query.CountAsync();

            // Aplicar paginación
            var soluciones = await query
                .OrderByDescending(s => s.FechaCreacion)
                .Take(pageSize)
                .ToListAsync();

            var solucionesDto = soluciones.Select(s => new SolucionReporteDto
            {
                Id = s.Id,
                Descripcion = s.Descripcion,
                ObservacionId = s.ObservacionId,
                ResponsableId = s.ResponsableId,
                FechaCreacion = s.FechaCreacion,
                FechaImplementacion = s.FechaImplementacion,
                TotalEvidencias = s.EvidenciasSolucion?.Count ?? 0,
                Observacion = s.Observacion != null ? new ObservacionReporteSimpleDto
                {
                    Id = s.Observacion.Id,
                    Descripcion = s.Observacion.Descripcion
                } : null,
                Responsable = s.Responsable != null ? new ResponsableReporteDto
                {
                    Id = s.Responsable.Id,
                    NombreCompleto = s.Responsable.NombreCompleto
                } : null
            }).ToList();

            return new PagedResponse<SolucionReporteDto>
            {
                Success = true,
                Data = solucionesDto,
                TotalCount = totalCount,
                PageNumber = 1,
                PageSize = pageSize
            };
        }
    }
}
