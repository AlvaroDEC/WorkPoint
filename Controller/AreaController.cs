using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Areas;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateAreaDto dto)
        {
            await _areaService.CrearArea(dto);
            return Ok(new { mensaje = "Área creada correctamente" });
        }
        
        [HttpGet]
        public async Task<ActionResult<List<AreaDto>>> Obtener()
        {
            return Ok(await _areaService.ObtenerAreas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AreaDto>> ObtenerPorId(int id)
        {
            return Ok(await _areaService.ObtenerPorId(id));
        }

        [HttpPatch]
        public async Task<IActionResult> Actualizar(UpdateAreaDto dto)
        {
            await _areaService.ActualizarArea(dto);
            return Ok(new { mensaje = "Área actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _areaService.EliminarArea(id);
            return Ok(new { mensaje = "Área eliminada correctamente" });
        }
    }
}
