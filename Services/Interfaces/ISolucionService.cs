using ClaseEntityFramework.DTOs.Soluciones;
using ClaseEntityFramework.DTOs.Common;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface ISolucionService
    {
        Task CrearSolucion(CreateSolucionDto dto);
        Task<List<SolucionDto>> ObtenerSoluciones();
        Task<SolucionDto> ObtenerPorId(int id);
        Task ActualizarSolucion(UpdateSolucionDto dto);
        Task EliminarSolucion(int id);
        Task<List<SolucionDto>> ObtenerSolucionesPorObservacion(int observacionId);
        Task<List<SolucionDto>> ObtenerSolucionesPorResponsable(int responsableId);
        Task<PagedResponse<SolucionReporteDto>> ObtenerParaReportesAsync(string? fechaDesde, string? fechaHasta, int pageSize);
    }
}
