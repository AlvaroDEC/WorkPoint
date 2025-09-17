using ClaseEntityFramework.DTOs.Seguimientos;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface ISeguimientoService
    {
        Task CrearSeguimiento(CreateSeguimientoDto dto);
    }
}
