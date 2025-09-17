using ClaseEntityFramework.DTOs.Observaciones;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IObservacionService
    {
        Task ActualizarParcialAsync(PatchObservacionDto dto);

    }
}