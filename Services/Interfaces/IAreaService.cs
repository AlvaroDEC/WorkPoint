using ClaseEntityFramework.DTOs.Areas;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IAreaService
    {
        Task CrearArea(CreateAreaDto dto);
        Task<List<AreaDto>> ObtenerAreas();
        Task<AreaDto> ObtenerPorId(int id);
        Task ActualizarArea(UpdateAreaDto dto);
        Task EliminarArea(int id);
    }
}