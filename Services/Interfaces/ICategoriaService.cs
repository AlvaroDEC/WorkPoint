using ClaseEntityFramework.DTOs.Categorias;
using ClaseEntityFramework.DTOs.Common;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task CrearCategoria(CreateCategoriaDto dto);
        Task<List<CategoriaDto>> ObtenerCategorias();
        Task<CategoriaDto> ObtenerPorId(int id);
        Task ActualizarCategoria(UpdateCategoriaDto dto);
        Task EliminarCategoria(int id);
        Task<PagedResponse<CategoriaReporteDto>> ObtenerParaReportesAsync(int pageSize);
    }
}
