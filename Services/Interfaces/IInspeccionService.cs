using ClaseEntityFramework.DTOs.Inspecciones;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IInspeccionService
    {
        Task<int> CrearInspeccionConObservacionesAsync(CreateInspeccionDto dto);
        Task<InspeccionCompletaDto> ObtenerInspeccionPorId(int id);
        Task<List<InspeccionListaDto>> ObtenerTodasAsync();
        Task ActualizarInspeccionCompletaAsync(PatchInspeccionDto dto);
        Task EliminarAsync(int id);

    }
}
