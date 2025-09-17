using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Soluciones;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolucionController : ControllerBase
    {
        private readonly ISolucionService _solucionService;

        public SolucionController(ISolucionService solucionService)
        {
            _solucionService = solucionService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateSolucionDto dto)
        {
            await _solucionService.CrearSolucion(dto);
            return Ok(new { mensaje = "Solución creada correctamente" });
        }

        [HttpGet]
        public async Task<ActionResult<List<SolucionDto>>> Obtener()
        {
            return Ok(await _solucionService.ObtenerSoluciones());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolucionDto>> ObtenerPorId(int id)
        {
            return Ok(await _solucionService.ObtenerPorId(id));
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] UpdateSolucionDto dto)
        {
            await _solucionService.ActualizarSolucion(dto);
            return Ok(new { mensaje = "Solución actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _solucionService.EliminarSolucion(id);
            return Ok(new { mensaje = "Solución eliminada correctamente" });
        }

        [HttpGet("por-observacion/{observacionId}")]
        public async Task<ActionResult<List<SolucionDto>>> ObtenerPorObservacion(int observacionId)
        {
            return Ok(await _solucionService.ObtenerSolucionesPorObservacion(observacionId));
        }

        [HttpGet("por-responsable/{responsableId}")]
        public async Task<ActionResult<List<SolucionDto>>> ObtenerPorResponsable(int responsableId)
        {
            return Ok(await _solucionService.ObtenerSolucionesPorResponsable(responsableId));
        }
    }
}
