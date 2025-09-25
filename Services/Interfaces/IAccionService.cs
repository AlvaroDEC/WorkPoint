using ClaseEntityFramework.DTOs.Acciones;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IAccionService
    {
        Task CrearAccion(CreateAccionDto dto);
        Task<List<AccionDto>> ObtenerAcciones();
        Task<AccionDto> ObtenerPorId(int id);
        Task ActualizarAccion(UpdateAccionDto dto);
        Task EliminarAccion(int id);
        Task EliminarTodasLasAcciones();
    }
}
