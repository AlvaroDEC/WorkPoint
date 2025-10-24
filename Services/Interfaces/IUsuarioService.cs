using ClaseEntityFramework.DTOs.Usuarios;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> CrearUsuarioAsync(CreateUsuarioDto dto);
        Task<List<UsuarioDto>> ObtenerUsuariosAsync();
        Task<UsuarioDto> ActualizarParcialmenteUsuarioAsync(int id, UpdateUsuarioDto dto);
        Task<UsuarioDto> ObtenerUsuarioPorIdAsync(int id);
        Task EliminarUsuarioAsync(int id);
        Task EliminarUsuarioForzadoAsync(int id); // ⚠️ Solo para testing
    }
}
