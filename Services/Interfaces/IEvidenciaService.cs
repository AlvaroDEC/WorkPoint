using ClaseEntityFramework.DTOs.Evidencias;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IEvidenciaService
    {
        Task<int> CrearEvidenciaAsync(CreateEvidenciaDto dto);
        Task<EvidenciaDto?> ObtenerPorIdAsync(int id);
        Task<List<EvidenciaDto>> ObtenerPorObservacionAsync(int observacionId);
        Task EliminarAsync(int id);
    }
}
