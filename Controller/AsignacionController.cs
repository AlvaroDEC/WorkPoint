using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Asignaciones;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionController : ControllerBase
    {
        private readonly IAsignacionService _asignacionService;

        public AsignacionController(IAsignacionService asignacionService)
        {
            _asignacionService = asignacionService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateAsignacionDto dto)
        {
            await _asignacionService.CrearAsignacion(dto);
            return Ok(new { mensaje = "Asignación creada correctamente" });
        }

        [HttpGet]
        public async Task<ActionResult<List<AsignacionDto>>> Obtener()
        {
            return Ok(await _asignacionService.ObtenerAsignaciones());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AsignacionDto>> ObtenerPorId(int id)
        {
            return Ok(await _asignacionService.ObtenerPorId(id));
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] UpdateAsignacionDto dto)
        {
            await _asignacionService.ActualizarAsignacion(dto);
            return Ok(new { mensaje = "Asignación actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _asignacionService.EliminarAsignacion(id);
            return Ok(new { mensaje = "Asignación eliminada correctamente" });
        }

        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<List<AsignacionDto>>> ObtenerPorUsuario(int id)
        {
            return Ok(await _asignacionService.ObtenerAsignacionesPorUsuario(id));
        }

        [HttpGet("area/{id}")]
        public async Task<ActionResult<List<AsignacionDto>>> ObtenerPorArea(int id)
        {
            return Ok(await _asignacionService.ObtenerAsignacionesPorArea(id));
        }
    }
}
