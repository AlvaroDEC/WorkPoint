using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.Services.Interfaces;
using ClaseEntityFramework.DTOs.Evidencias;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvidenciaController : ControllerBase
    {
        private readonly IEvidenciaService _evidenciaService;

        public EvidenciaController(IEvidenciaService evidenciaService)
        {
            _evidenciaService = evidenciaService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> SubirImagenBase64([FromBody] CreateEvidenciaDto dto)
        {
            try
            {
                var id = await _evidenciaService.CrearEvidenciaAsync(dto);
                return Ok(new { 
                    mensaje = "Evidencia subida correctamente", 
                    evidenciaId = id,
                    tamañoBytes = dto.TamañoBytes
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EvidenciaDto>> ObtenerPorId(int id)
        {
            try
            {
                var evidencia = await _evidenciaService.ObtenerPorIdAsync(id);
                if (evidencia == null)
                    return NotFound(new { mensaje = "Evidencia no encontrada" });
                
                return Ok(evidencia);
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
                await _evidenciaService.EliminarAsync(id);
                return Ok(new { mensaje = "Evidencia eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpGet("por-observacion/{observacionId}")]
        public async Task<ActionResult<List<EvidenciaDto>>> ObtenerPorObservacion(int observacionId)
        {
            try
            {
                var evidencias = await _evidenciaService.ObtenerPorObservacionAsync(observacionId);
                return Ok(evidencias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }
    }
}