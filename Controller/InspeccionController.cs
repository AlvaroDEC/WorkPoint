using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Inspecciones;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InspeccionController : ControllerBase
    {
        private readonly IInspeccionService _inspeccionService;

        public InspeccionController(IInspeccionService inspeccionService)
        {
            _inspeccionService = inspeccionService;
        }

        [HttpPost]
        public async Task<ActionResult> CrearInspeccion(CreateInspeccionDto dto)
        {
            var id = await _inspeccionService.CrearInspeccionConObservacionesAsync(dto);
            return Ok(new { mensaje = "Inspección registrada", inspeccionId = id });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InspeccionCompletaDto>> ObtenerPorId(int id)
        {
            try
            {
                var dto = await _inspeccionService.ObtenerInspeccionPorId(id);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<InspeccionListaDto>>> ObtenerTodas()
        {
            var lista = await _inspeccionService.ObtenerTodasAsync();
            return Ok(lista);
        }

        [HttpPatch]
        public async Task<IActionResult> ActualizarInspeccionCompletaAsync([FromBody] PatchInspeccionDto dto)
        {
            await _inspeccionService.ActualizarInspeccionCompletaAsync(dto);
            return Ok(new { mensaje = "Inspección actualizada parcialmente" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _inspeccionService.EliminarAsync(id);
            return Ok(new { mensaje = "Inspección eliminada correctamente" });
        }
    }
}