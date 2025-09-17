using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.EvidenciasSolucion;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvidenciaSolucionController : ControllerBase
    {
        private readonly IEvidenciaSolucionService _evidenciaSolucionService;

        public EvidenciaSolucionController(IEvidenciaSolucionService evidenciaSolucionService)
        {
            _evidenciaSolucionService = evidenciaSolucionService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateEvidenciaSolucionDto dto)
        {
            await _evidenciaSolucionService.CrearEvidenciaSolucion(dto);
            return Ok(new { mensaje = "Evidencia de solución creada correctamente" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EvidenciaSolucionDto>> ObtenerPorId(int id)
        {
            return Ok(await _evidenciaSolucionService.ObtenerPorId(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _evidenciaSolucionService.EliminarEvidenciaSolucion(id);
            return Ok(new { mensaje = "Evidencia de solución eliminada correctamente" });
        }

        [HttpGet("por-solucion/{solucionId}")]
        public async Task<ActionResult<List<EvidenciaSolucionDto>>> ObtenerPorSolucion(int solucionId)
        {
            return Ok(await _evidenciaSolucionService.ObtenerEvidenciasPorSolucion(solucionId));
        }
    }
}
