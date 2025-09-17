using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Observaciones;
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

        [HttpPatch]
        public async Task<IActionResult> ActualizarParcial([FromBody] PatchObservacionDto dto)
        {
            await _observacionService.ActualizarParcialAsync(dto);
            return Ok(new { mensaje = "Observación actualizada correctamente" });
        }
    }
}
