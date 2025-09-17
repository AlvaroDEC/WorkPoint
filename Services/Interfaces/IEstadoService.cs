using ClaseEntityFramework.DTOs.Estados;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IEstadoService
    {
        Task CrearEstado(CreateEstadoDto dto);
        Task<List<EstadoDto>> ObtenerEstados();
        Task<EstadoDto> ObtenerPorId(int id);
        Task ActualizarEstado(UpdateEstadoDto dto);
        Task EliminarEstado(int id);
    }
}
