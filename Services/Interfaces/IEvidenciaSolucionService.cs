using ClaseEntityFramework.DTOs.EvidenciasSolucion;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IEvidenciaSolucionService
    {
        Task CrearEvidenciaSolucion(CreateEvidenciaSolucionDto dto);
        Task<EvidenciaSolucionDto> ObtenerPorId(int id);
        Task EliminarEvidenciaSolucion(int id);
        Task<List<EvidenciaSolucionDto>> ObtenerEvidenciasPorSolucion(int solucionId);
    }
}
