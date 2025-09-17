using ClaseEntityFramework.DTOs.AsignacionRoles;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IAsignacionRolesService
    {
        Task CrearAsignacionRoles(CreateAsignacionRolesDto dto);
        Task<List<AsignacionRolesDto>> ObtenerAsignacionRoles();
        Task<AsignacionRolesDto> ObtenerPorId(int id);
        Task ActualizarAsignacionRoles(UpdateAsignacionRolesDto dto);
        Task EliminarAsignacionRoles(int id);
        Task<List<AsignacionRolesDto>> ObtenerAsignacionRolesPorUsuario(int usuarioId);
        Task<List<AsignacionRolesDto>> ObtenerAsignacionRolesPorRol(int rolId);
    }
}
