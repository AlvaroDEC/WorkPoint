using ClaseEntityFramework.DTOs.Permisos;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IPermisoService
    {
        Task CrearPermiso(CreatePermisoDto dto);
    }
}
