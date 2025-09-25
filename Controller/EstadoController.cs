using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Estados;
using ClaseEntityFramework.DTOs.Common;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CreateEstadoDto dto)
    {
        await _estadoService.CrearEstado(dto);
        return Ok(new { mensaje = "Estado creado correctamente" });
    }
    
        /// <summary>
        /// Obtener estados para reportes
        /// </summary>
        [HttpGet("reportes")]
        public async Task<ActionResult<PagedResponse<EstadoReporteDto>>> ObtenerParaReportes(
            [FromQuery] int pageSize = 1000)
        {
            try
            {
                var resultado = await _estadoService.ObtenerParaReportesAsync(pageSize);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<EstadoDto>>> Obtener()
        {
            return Ok(await _estadoService.ObtenerEstados());
        }

    [HttpGet("{id}")]
    public async Task<ActionResult<EstadoDto>> ObtenerPorId(int id)
    {
        return Ok(await _estadoService.ObtenerPorId(id));
    }

    [HttpPatch]
    public async Task<IActionResult> Actualizar(UpdateEstadoDto dto)
    {
        await _estadoService.ActualizarEstado(dto);
        return Ok(new { mensaje = "Estado actualizado correctamente" });
    }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _estadoService.EliminarEstado(id);
            return Ok(new { mensaje = "Estado eliminado correctamente" });
        }
    }
}
