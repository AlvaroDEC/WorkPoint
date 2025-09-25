using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Observaciones;
using ClaseEntityFramework.DTOs.Common;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObservacionController : ControllerBase
    {
        private readonly IObservacionService _observacionService;

        public ObservacionController(IObservacionService observacionService)
        {
            _observacionService = observacionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ObservacionListaDto>>> ObtenerTodas()
        {
            try
            {
                var observaciones = await _observacionService.ObtenerTodasAsync();
                return Ok(observaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Obtener observaciones para reportes con filtros
        /// </summary>
        [HttpGet("reportes")]
        public async Task<ActionResult<PagedResponse<ObservacionReporteDto>>> ObtenerParaReportes(
            [FromQuery] string? fechaDesde,
            [FromQuery] string? fechaHasta,
            [FromQuery] int? categoriaId,
            [FromQuery] int? estadoId,
            [FromQuery] int pageSize = 1000)
        {
            try
            {
                var resultado = await _observacionService.ObtenerParaReportesAsync(
                    fechaDesde, fechaHasta, categoriaId, estadoId, pageSize);
                
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObservacionCompletaDto>> ObtenerPorId(int id)
        {
            try
            {
                var observacion = await _observacionService.ObtenerPorIdAsync(id);
                if (observacion == null)
                    return NotFound(new { mensaje = "Observación no encontrada" });
                
                return Ok(observacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CrearObservacion([FromBody] CreateObservacionDto dto)
        {
            try
            {
                var id = await _observacionService.CrearObservacionAsync(dto);
                return Ok(new { mensaje = "Observación creada correctamente", observacionId = id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> ActualizarParcial([FromBody] PatchObservacionDto dto)
        {
            try
            {
                await _observacionService.ActualizarParcialAsync(dto);
                return Ok(new { mensaje = "Observación actualizada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _observacionService.EliminarAsync(id);
                return Ok(new { mensaje = "Observación eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }
    }
}
