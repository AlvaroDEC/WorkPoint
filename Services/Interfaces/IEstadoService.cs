using ClaseEntityFramework.DTOs.Estados;
using ClaseEntityFramework.DTOs.Common;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IEstadoService
    {
        Task CrearEstado(CreateEstadoDto dto);
        Task<List<EstadoDto>> ObtenerEstados();
        Task<EstadoDto> ObtenerPorId(int id);
        Task ActualizarEstado(UpdateEstadoDto dto);
        Task EliminarEstado(int id);
        Task<PagedResponse<EstadoReporteDto>> ObtenerParaReportesAsync(int pageSize);
    }
}
