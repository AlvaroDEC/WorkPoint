using AutoMapper;
using ClaseEntityFramework.DTOs.Inspecciones;
using ClaseEntityFramework.DTOs.Common;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class InspeccionService : IInspeccionService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public InspeccionService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CrearInspeccionConObservacionesAsync(CreateInspeccionDto dto)
        {
            var inspeccion = _mapper.Map<Inspeccion>(dto);
            // ✅ Asegurar valores por defecto
            inspeccion.Fecha = DateTime.UtcNow;
            inspeccion.Estado = "Programada";
            inspeccion.FechaCreacion = DateTime.UtcNow;

            _context.Inspecciones.Add(inspeccion);
            await _context.SaveChangesAsync();

            foreach (var obsDto in dto.Observaciones)
            {
                var estadoPendiente = await _context.Estados.FirstOrDefaultAsync(e => e.Nombre == "Pendiente");
                if (estadoPendiente == null)
                {
                    estadoPendiente = new Estado { Nombre = "Pendiente", Descripcion = "Observación pendiente de revisión" };
                    _context.Estados.Add(estadoPendiente);
                    await _context.SaveChangesAsync();
                }

                var observacion = new Observacion
                {
                    Descripcion = obsDto.Descripcion,
                    CriterioDeGravedadId = obsDto.CriterioDeGravedadId,
                    CategoriaId = obsDto.CategoriaId,
                    EstadoId = estadoPendiente.Id,
                    FechaCreacion = DateTime.UtcNow,
                    InspeccionId = inspeccion.Id,
                    ResponsableId = obsDto.ResponsableId
                };

                _context.Observaciones.Add(observacion);
                await _context.SaveChangesAsync();

                if (obsDto.Evidencias != null)
                {
                    foreach (var ev in obsDto.Evidencias)
                    {
                        var evidencia = new Evidencia
                        {
                            ArchivoBase64 = ev.ArchivoBase64,
                            TipoArchivo = ev.TipoArchivo,
                            TamañoBytes = ev.TamañoBytes > 0 ? ev.TamañoBytes : ClaseEntityFramework.Helpers.Base64Helper.CalcularTamañoBytes(ev.ArchivoBase64),
                            FechaRegistro = DateTime.UtcNow,
                            ObservacionId = observacion.Id
                        };
                        _context.Evidencias.Add(evidencia);
                    }
                }
            }

            await _context.SaveChangesAsync();

            return inspeccion.Id;
        }

        public async Task<InspeccionCompletaDto> ObtenerInspeccionPorId(int id)
        {
            var inspeccion = await _context.Inspecciones
                .Include(i => i.Area)
                .Include(i => i.Auditor)
                .Include(i => i.Observaciones)
                    .ThenInclude(o => o.Evidencias)
                .Include(i => i.Observaciones)
                    .ThenInclude(o => o.CriterioDeGravedad)
                .Include(i => i.Observaciones)
                    .ThenInclude(o => o.Responsable)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inspeccion == null)
                throw new Exception("Inspección no encontrada");

            return new InspeccionCompletaDto
            {
                Id = inspeccion.Id,
                Fecha = inspeccion.Fecha,
                Estado = inspeccion.Estado.ToString(),
                NombreAuditor = inspeccion.Auditor?.NombreCompleto ?? "No asignado",
                NombreArea = inspeccion.Area?.Nombre ?? "No asignado",
                Observaciones = inspeccion.Observaciones.Select(o => new ObservacionConEvidenciaDto
                {
                    Descripcion = o.Descripcion,
                    Criterio = o.CriterioDeGravedad?.Descripcion ?? "Sin criterio",
                    Responsable = o.Responsable?.NombreCompleto ?? "Sin responsable",
                    Evidencias = o.Evidencias?.Select(e => e.ArchivoBase64).ToList() ?? new List<string>()
                }).ToList()
            };
        }
        public async Task<List<InspeccionListaDto>> ObtenerTodasAsync()
        {
            var inspecciones = await _context.Inspecciones
                .Include(i => i.Area)
                .Include(i => i.Auditor)
                .OrderByDescending(i => i.Fecha)
                .ToListAsync();

            return inspecciones.Select(i => new InspeccionListaDto
            {
                Id = i.Id,
                Fecha = i.Fecha,
                NombreArea = i.Area?.Nombre ?? "Sin área",
                NombreAuditor = i.Auditor?.NombreCompleto ?? "Sin auditor",
                Estado = i.Estado
            }).ToList();
        }
        public async Task ActualizarInspeccionCompletaAsync(PatchInspeccionDto dto)
        {
            var inspeccion = await _context.Inspecciones
                .Include(i => i.Observaciones)
                    .ThenInclude(o => o.Evidencias)
                .FirstOrDefaultAsync(i => i.Id == dto.Id);

            if (inspeccion == null)
                throw new Exception("Inspección no encontrada");

            // Actualiza campos principales manualmente (sin AutoMapper para evitar problemas)
            if (dto.AreaId.HasValue)
                inspeccion.AreaId = dto.AreaId.Value;
            
            if (dto.AuditorId.HasValue)
                inspeccion.AuditorId = dto.AuditorId.Value;
                
            if (!string.IsNullOrEmpty(dto.Estado))
                inspeccion.Estado = dto.Estado;
            
            // Asegurar que la fecha sea UTC si se proporciona
            if (dto.Fecha.HasValue)
                inspeccion.Fecha = dto.Fecha.Value.ToUniversalTime();

            // Procesar observaciones si vienen
            if (dto.Observaciones != null && dto.Observaciones.Any())
            {
                foreach (var obsDto in dto.Observaciones)
                {
                    Observacion? observacion;

                    if (obsDto.Id.HasValue)
                    {
                        observacion = inspeccion.Observaciones.FirstOrDefault(o => o.Id == obsDto.Id.Value);
                        if (observacion == null) continue;
                    }
                    else
                    {
                        var estadoPendiente = await _context.Estados.FirstOrDefaultAsync(e => e.Nombre == "Pendiente");
                        if (estadoPendiente == null)
                        {
                            estadoPendiente = new Estado { Nombre = "Pendiente", Descripcion = "Observación pendiente de revisión" };
                            _context.Estados.Add(estadoPendiente);
                            await _context.SaveChangesAsync();
                        }

                        observacion = new Observacion
                        {
                            InspeccionId = inspeccion.Id,
                            FechaCreacion = DateTime.UtcNow,
                            EstadoId = estadoPendiente.Id
                        };
                        _context.Observaciones.Add(observacion);
                        inspeccion.Observaciones.Add(observacion);
                    }

                    if (!string.IsNullOrWhiteSpace(obsDto.Descripcion))
                        observacion.Descripcion = obsDto.Descripcion;

                    if (obsDto.CriterioDeGravedadId.HasValue)
                        observacion.CriterioDeGravedadId = obsDto.CriterioDeGravedadId.Value;

                    if (obsDto.ResponsableId.HasValue)
                        observacion.ResponsableId = obsDto.ResponsableId.Value;

                    if (!string.IsNullOrWhiteSpace(obsDto.Estado))
                    {
                        var estado = await _context.Estados.FirstOrDefaultAsync(e => e.Nombre == obsDto.Estado);
                        if (estado != null)
                            observacion.EstadoId = estado.Id;
                    }

                    // Procesar evidencias
                    if (obsDto.Evidencias != null && obsDto.Evidencias.Any())
                    {
                        foreach (var evDto in obsDto.Evidencias)
                        {
                            Evidencia? evidencia;

                            if (evDto.Id.HasValue)
                            {
                                evidencia = observacion.Evidencias?.FirstOrDefault(e => e.Id == evDto.Id.Value);
                                if (evidencia == null) continue;
                            }
                            else
                            {
                                evidencia = new Evidencia
                                {
                                    FechaRegistro = DateTime.UtcNow,
                                    ObservacionId = observacion.Id
                                };
                                _context.Evidencias.Add(evidencia);
                                observacion.Evidencias ??= new List<Evidencia>();
                                observacion.Evidencias.Add(evidencia);
                            }

                            if (!string.IsNullOrWhiteSpace(evDto.ArchivoBase64))
                                evidencia.ArchivoBase64 = evDto.ArchivoBase64;

                            if (!string.IsNullOrWhiteSpace(evDto.TipoArchivo))
                                evidencia.TipoArchivo = evDto.TipoArchivo;
                        }
                    }
                }
            }

            // Validación de seguridad: asegurar que Estado nunca sea null
            if (string.IsNullOrWhiteSpace(inspeccion.Estado))
            {
                inspeccion.Estado = "Programada"; // Estado por defecto
            }

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var inspeccion = await _context.Inspecciones
                .Include(i => i.Observaciones)
                    .ThenInclude(o => o.Evidencias)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inspeccion == null)
                throw new Exception("Inspección no encontrada");

            // Eliminar evidencias
            foreach (var obs in inspeccion.Observaciones)
            {
                _context.Evidencias.RemoveRange(obs.Evidencias);
            }

            // Eliminar observaciones
            _context.Observaciones.RemoveRange(inspeccion.Observaciones);

            // Eliminar la inspección
            _context.Inspecciones.Remove(inspeccion);

            await _context.SaveChangesAsync();
        }

        public async Task<PagedResponse<InspeccionReporteDto>> ObtenerParaReportesAsync(string? fechaDesde, string? fechaHasta, int pageSize)
        {
            var query = _context.Inspecciones
                .Include(i => i.Area)
                .Include(i => i.Auditor)
                .AsQueryable();

            // Aplicar filtros de fecha
            if (!string.IsNullOrEmpty(fechaDesde) && DateTime.TryParse(fechaDesde, out var fechaInicio))
            {
                query = query.Where(i => i.Fecha >= fechaInicio);
            }

            if (!string.IsNullOrEmpty(fechaHasta) && DateTime.TryParse(fechaHasta, out var fechaFin))
            {
                query = query.Where(i => i.Fecha <= fechaFin.AddDays(1).AddTicks(-1));
            }

            // Obtener total de registros
            var totalCount = await query.CountAsync();

            // Aplicar paginación
            var inspecciones = await query
                .OrderByDescending(i => i.Fecha)
                .Take(pageSize)
                .ToListAsync();

            var inspeccionesDto = inspecciones.Select(i => new InspeccionReporteDto
            {
                Id = i.Id,
                Fecha = i.Fecha,
                Estado = i.Estado,
                FechaCreacion = i.FechaCreacion,
                AreaId = i.AreaId,
                AuditorId = i.AuditorId,
                NombreArea = i.Area?.Nombre ?? "Sin área",
                NombreAuditor = i.Auditor?.NombreCompleto ?? "Sin auditor",
                Area = i.Area != null ? new AreaReporteDto
                {
                    Id = i.Area.Id,
                    Nombre = i.Area.Nombre
                } : null,
                Auditor = i.Auditor != null ? new AuditorReporteDto
                {
                    Id = i.Auditor.Id,
                    NombreCompleto = i.Auditor.NombreCompleto
                } : null
            }).ToList();

            return new PagedResponse<InspeccionReporteDto>
            {
                Success = true,
                Data = inspeccionesDto,
                TotalCount = totalCount,
                PageNumber = 1,
                PageSize = pageSize
            };
        }
    }
}