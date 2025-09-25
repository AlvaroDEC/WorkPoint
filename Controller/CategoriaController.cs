using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Categorias;
using ClaseEntityFramework.DTOs.Common;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CreateCategoriaDto dto)
    {
        await _categoriaService.CrearCategoria(dto);
        return Ok(new { mensaje = "Categoría creada correctamente" });
    }
    
        /// <summary>
        /// Obtener categorías para reportes
        /// </summary>
        [HttpGet("reportes")]
        public async Task<ActionResult<PagedResponse<CategoriaReporteDto>>> ObtenerParaReportes(
            [FromQuery] int pageSize = 1000)
        {
            try
            {
                var resultado = await _categoriaService.ObtenerParaReportesAsync(pageSize);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaDto>>> Obtener()
        {
            return Ok(await _categoriaService.ObtenerCategorias());
        }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoriaDto>> ObtenerPorId(int id)
    {
        return Ok(await _categoriaService.ObtenerPorId(id));
    }

    [HttpPatch]
    public async Task<IActionResult> Actualizar(UpdateCategoriaDto dto)
    {
        await _categoriaService.ActualizarCategoria(dto);
        return Ok(new { mensaje = "Categoría actualizada correctamente" });
    }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _categoriaService.EliminarCategoria(id);
            return Ok(new { mensaje = "Categoría eliminada correctamente" });
        }
    }
}
