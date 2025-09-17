using ClaseEntityFramework.DTOs.Soluciones;

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
    }
}
