using ClaseEntityFramework.DTOs.Asignaciones;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IAsignacionService
    {
        Task CrearAsignacion(CreateAsignacionDto dto);
        Task<List<AsignacionDto>> ObtenerAsignaciones();
        Task<AsignacionDto> ObtenerPorId(int id);
        Task ActualizarAsignacion(UpdateAsignacionDto dto);
        Task EliminarAsignacion(int id);
        Task<List<AsignacionDto>> ObtenerAsignacionesPorUsuario(int usuarioId);
        Task<List<AsignacionDto>> ObtenerAsignacionesPorArea(int areaId);
    }
}
