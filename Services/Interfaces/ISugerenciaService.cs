using ClaseEntityFramework.DTOs.Sugerencias;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface ISugerenciaService
    {
        Task CrearSugerencia(CreateSugerenciaDto dto);
        Task<List<SugerenciaDto>> ObtenerSugerencias();
        Task<SugerenciaDto> ObtenerPorId(int id);
        Task ActualizarSugerencia(UpdateSugerenciaDto dto);
        Task EliminarSugerencia(int id);
        Task<List<SugerenciaDto>> ObtenerSugerenciasPorProblema(int problemaId);
    }
}
