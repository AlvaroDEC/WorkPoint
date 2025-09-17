using ClaseEntityFramework.DTOs.Problemas;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IProblemaService
    {
        Task CrearProblema(CreateProblemaDto dto);
        Task<List<ProblemaDto>> ObtenerProblemas();
        Task<ProblemaDto> ObtenerPorId(int id);
        Task ActualizarProblema(UpdateProblemaDto dto);
        Task EliminarProblema(int id);
    }
}
