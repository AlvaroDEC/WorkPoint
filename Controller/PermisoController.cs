using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Permisos;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisoController : ControllerBase
    {
        private readonly IPermisoService _permisoService;

        public PermisoController(IPermisoService permisoService)
        {
            _permisoService = permisoService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreatePermisoDto dto)
        {
            await _permisoService.CrearPermiso(dto);
            return Ok(new { mensaje = "Permiso creado correctamente" });
        }
    }
}
