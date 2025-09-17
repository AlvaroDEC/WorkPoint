using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Seguimientos;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguimientoController : ControllerBase
    {
        private readonly ISeguimientoService _seguimientoService;

        public SeguimientoController(ISeguimientoService seguimientoService)
        {
            _seguimientoService = seguimientoService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateSeguimientoDto dto)
        {
            await _seguimientoService.CrearSeguimiento(dto);
            return Ok(new { mensaje = "Seguimiento creado correctamente" });
        }
    }
}
