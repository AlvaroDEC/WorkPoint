using ClaseEntityFramework.DTOs.CriteriosDeGravedad;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface ICriterioService
    {
        Task CrearCriterio(CreateCriterioDto dto);
        Task<List<CriterioDto>> ObtenerCriterios();
        Task<CriterioDto> ObtenerPorId(int id);
        Task ActualizarCriterio(UpdateCriterioDto dto);
        Task EliminarCriterio(int id);
    }
}