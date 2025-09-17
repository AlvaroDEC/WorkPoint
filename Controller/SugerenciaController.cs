using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Sugerencias;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SugerenciaController : ControllerBase
    {
        private readonly ISugerenciaService _sugerenciaService;

        public SugerenciaController(ISugerenciaService sugerenciaService)
        {
            _sugerenciaService = sugerenciaService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateSugerenciaDto dto)
        {
            await _sugerenciaService.CrearSugerencia(dto);
            return Ok(new { mensaje = "Sugerencia creada correctamente" });
        }

        [HttpGet]
        public async Task<ActionResult<List<SugerenciaDto>>> Obtener()
        {
            return Ok(await _sugerenciaService.ObtenerSugerencias());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SugerenciaDto>> ObtenerPorId(int id)
        {
            return Ok(await _sugerenciaService.ObtenerPorId(id));
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] UpdateSugerenciaDto dto)
        {
            await _sugerenciaService.ActualizarSugerencia(dto);
            return Ok(new { mensaje = "Sugerencia actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _sugerenciaService.EliminarSugerencia(id);
            return Ok(new { mensaje = "Sugerencia eliminada correctamente" });
        }

        [HttpGet("por-problema/{problemaId}")]
        public async Task<ActionResult<List<SugerenciaDto>>> ObtenerPorProblema(int problemaId)
        {
            return Ok(await _sugerenciaService.ObtenerSugerenciasPorProblema(problemaId));
        }
    }
}
