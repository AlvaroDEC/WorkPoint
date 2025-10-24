using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Observaciones;
using ClaseEntityFramework.DTOs.Common;
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

        public async Task<List<ObservacionListaDto>> ObtenerTodasAsync()
        {
            var observaciones = await _context.Observaciones
                .Include(o => o.CriterioDeGravedad)
                .Include(o => o.Categoria)
                .Include(o => o.Estado)
                .Include(o => o.Responsable)
                .Include(o => o.Inspeccion)
                    .ThenInclude(i => i.Area)
                .Include(o => o.Evidencias)
                .Include(o => o.Soluciones)
                .Include(o => o.Seguimientos)
                .OrderByDescending(o => o.FechaCreacion)
                .ToListAsync();

            return observaciones.Select(o => _mapper.Map<ObservacionListaDto>(o)).ToList();
        }

        public async Task<ObservacionCompletaDto?> ObtenerPorIdAsync(int id)
        {
            var observacion = await _context.Observaciones
                .Include(o => o.CriterioDeGravedad)
                .Include(o => o.Categoria)
                .Include(o => o.Estado)
                .Include(o => o.Responsable)
                .Include(o => o.Inspeccion)
                    .ThenInclude(i => i.Area)
                .Include(o => o.Evidencias)
                .Include(o => o.Soluciones)
                .Include(o => o.Seguimientos)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (observacion == null)
                return null;

            return _mapper.Map<ObservacionCompletaDto>(observacion);
        }

        public async Task<int> CrearObservacionAsync(CreateObservacionDto dto)
        {
            var observacion = _mapper.Map<Models.Observacion>(dto);
            observacion.FechaCreacion = DateTime.UtcNow;

            _context.Observaciones.Add(observacion);
            await _context.SaveChangesAsync();

            return observacion.Id;
        }

        public async Task ActualizarParcialAsync(PatchObservacionDto dto)
        {
            var observacion = await _context.Observaciones.FindAsync(dto.Id);
            if (observacion == null)
                throw new Exception("Observación no encontrada");

            // Usar AutoMapper para campos simples con configuración de patch
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

        public async Task EliminarAsync(int id)
        {
            var observacion = await _context.Observaciones
                .Include(o => o.Evidencias)
                .Include(o => o.Soluciones)
                .Include(o => o.Seguimientos)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (observacion == null)
                throw new Exception("Observación no encontrada");

            // Eliminar evidencias
            if (observacion.Evidencias?.Any() == true)
                _context.Evidencias.RemoveRange(observacion.Evidencias);

            // Eliminar soluciones
            if (observacion.Soluciones?.Any() == true)
                _context.Soluciones.RemoveRange(observacion.Soluciones);

            // Eliminar seguimientos
            if (observacion.Seguimientos?.Any() == true)
                _context.Seguimientos.RemoveRange(observacion.Seguimientos);

            // Eliminar la observación
            _context.Observaciones.Remove(observacion);

            await _context.SaveChangesAsync();
        }

        public async Task<PagedResponse<ObservacionReporteDto>> ObtenerParaReportesAsync(string? fechaDesde, string? fechaHasta, int? categoriaId, int? estadoId, int pageSize)
        {
            var query = _context.Observaciones
                .Include(o => o.CriterioDeGravedad)
                .Include(o => o.Categoria)
                .Include(o => o.Estado)
                .Include(o => o.Responsable)
                .AsQueryable();

            // Aplicar filtros
            if (!string.IsNullOrEmpty(fechaDesde) && DateTime.TryParse(fechaDesde, out var fechaInicio))
            {
                query = query.Where(o => o.FechaCreacion >= fechaInicio);
            }

            if (!string.IsNullOrEmpty(fechaHasta) && DateTime.TryParse(fechaHasta, out var fechaFin))
            {
                query = query.Where(o => o.FechaCreacion <= fechaFin.AddDays(1).AddTicks(-1));
            }

            if (categoriaId.HasValue)
            {
                query = query.Where(o => o.CategoriaId == categoriaId.Value);
            }

            if (estadoId.HasValue)
            {
                query = query.Where(o => o.EstadoId == estadoId.Value);
            }

            // Obtener total de registros
            var totalCount = await query.CountAsync();

            // Aplicar paginación
            var observaciones = await query
                .OrderByDescending(o => o.FechaCreacion)
                .Take(pageSize)
                .ToListAsync();

            var observacionesDto = observaciones.Select(o => new ObservacionReporteDto
            {
                Id = o.Id,
                Descripcion = o.Descripcion,
                FechaCreacion = o.FechaCreacion,
                InspeccionId = o.InspeccionId,
                CriterioDeGravedadId = o.CriterioDeGravedadId,
                CategoriaId = o.CategoriaId,
                EstadoId = o.EstadoId,
                ResponsableId = o.ResponsableId,
                CriterioDeGravedad = o.CriterioDeGravedad != null ? new CriterioDeGravedadReporteDto
                {
                    Id = o.CriterioDeGravedad.Id,
                    Nivel = o.CriterioDeGravedad.Nivel,
                    Codigo = o.CriterioDeGravedad.Codigo,
                    Descripcion = o.CriterioDeGravedad.Descripcion,
                    Color = o.CriterioDeGravedad.Color
                } : null,
                Categoria = o.Categoria != null ? new CategoriaObservacionReporteDto
                {
                    Id = o.Categoria.Id,
                    Nombre = o.Categoria.Nombre
                } : null,
                Estado = o.Estado != null ? new EstadoObservacionReporteDto
                {
                    Id = o.Estado.Id,
                    Nombre = o.Estado.Nombre
                } : null,
                Responsable = o.Responsable != null ? new ResponsableReporteDto
                {
                    Id = o.Responsable.Id,
                    NombreCompleto = o.Responsable.NombreCompleto
                } : null
            }).ToList();

            return new PagedResponse<ObservacionReporteDto>
            {
                Success = true,
                Data = observacionesDto,
                TotalCount = totalCount,
                PageNumber = 1,
                PageSize = pageSize
            };
        }
    }
}