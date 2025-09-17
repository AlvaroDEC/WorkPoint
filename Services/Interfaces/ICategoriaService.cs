using ClaseEntityFramework.DTOs.Categorias;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task CrearCategoria(CreateCategoriaDto dto);
        Task<List<CategoriaDto>> ObtenerCategorias();
        Task<CategoriaDto> ObtenerPorId(int id);
        Task ActualizarCategoria(UpdateCategoriaDto dto);
        Task EliminarCategoria(int id);
    }
}
