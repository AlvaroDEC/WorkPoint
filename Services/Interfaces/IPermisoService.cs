using ClaseEntityFramework.DTOs.Permisos;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IPermisoService
    {
        Task CrearPermiso(CreatePermisoDto dto);
        Task<List<PermisoDto>> ObtenerPermisosPorRol(int rolId);
        Task AsignarPermisosARol(int rolId, List<int> accionIds);
        Task EliminarPermiso(int rolId, int accionId);
    }
}
