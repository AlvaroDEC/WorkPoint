using ClaseEntityFramework.DTOs.Inspecciones;
using ClaseEntityFramework.DTOs.Common;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IInspeccionService
    {
        Task<int> CrearInspeccionConObservacionesAsync(CreateInspeccionDto dto);
        Task<InspeccionCompletaDto> ObtenerInspeccionPorId(int id);
        Task<List<InspeccionListaDto>> ObtenerTodasAsync();
        Task ActualizarInspeccionCompletaAsync(PatchInspeccionDto dto);
        Task EliminarAsync(int id);
        Task<PagedResponse<InspeccionReporteDto>> ObtenerParaReportesAsync(string? fechaDesde, string? fechaHasta, int pageSize);
    }
}
