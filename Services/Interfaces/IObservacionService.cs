using ClaseEntityFramework.DTOs.Observaciones;
using ClaseEntityFramework.DTOs.Common;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IObservacionService
    {
        Task<List<ObservacionListaDto>> ObtenerTodasAsync();
        Task<ObservacionCompletaDto?> ObtenerPorIdAsync(int id);
        Task<int> CrearObservacionAsync(CreateObservacionDto dto);
        Task ActualizarParcialAsync(PatchObservacionDto dto);
        Task EliminarAsync(int id);
        Task<PagedResponse<ObservacionReporteDto>> ObtenerParaReportesAsync(string? fechaDesde, string? fechaHasta, int? categoriaId, int? estadoId, int pageSize);
    }
}