using ClaseEntityFramework.DTOs.Roles;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IRolService
    {
        Task CrearRol(CreateRolDto dto);
        Task<List<RolDto>> ObtenerRoles();
        Task<RolDto> ObtenerPorId(int id);
        Task ActualizarRol(UpdateRolDto dto);
        Task EliminarRol(int id);
    }
}