using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.AsignacionRoles;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionRolesController : ControllerBase
    {
        private readonly IAsignacionRolesService _asignacionRolesService;

        public AsignacionRolesController(IAsignacionRolesService asignacionRolesService)
        {
            _asignacionRolesService = asignacionRolesService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateAsignacionRolesDto dto)
        {
            await _asignacionRolesService.CrearAsignacionRoles(dto);
            return Ok(new { mensaje = "Asignación de roles creada correctamente" });
        }

        [HttpGet]
        public async Task<ActionResult<List<AsignacionRolesDto>>> Obtener()
        {
            return Ok(await _asignacionRolesService.ObtenerAsignacionRoles());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AsignacionRolesDto>> ObtenerPorId(int id)
        {
            return Ok(await _asignacionRolesService.ObtenerPorId(id));
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] UpdateAsignacionRolesDto dto)
        {
            await _asignacionRolesService.ActualizarAsignacionRoles(dto);
            return Ok(new { mensaje = "Asignación de roles actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _asignacionRolesService.EliminarAsignacionRoles(id);
            return Ok(new { mensaje = "Asignación de roles eliminada correctamente" });
        }

        [HttpGet("por-usuario/{usuarioId}")]
        public async Task<ActionResult<List<AsignacionRolesDto>>> ObtenerPorUsuario(int usuarioId)
        {
            return Ok(await _asignacionRolesService.ObtenerAsignacionRolesPorUsuario(usuarioId));
        }

        [HttpGet("por-rol/{rolId}")]
        public async Task<ActionResult<List<AsignacionRolesDto>>> ObtenerPorRol(int rolId)
        {
            return Ok(await _asignacionRolesService.ObtenerAsignacionRolesPorRol(rolId));
        }
    }
}
