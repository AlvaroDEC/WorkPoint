using ClaseEntityFramework.DTOs.Roles;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RolController : ControllerBase
{
    private readonly IRolService _rolService;

    public RolController(IRolService rolService)
    {
        _rolService = rolService;
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CreateRolDto dto)
    {
        await _rolService.CrearRol(dto);
        return Ok(new { mensaje = "Rol creado correctamente" });
    }

    [HttpGet]
    public async Task<ActionResult<List<RolDto>>> Obtener()
    {
        return Ok(await _rolService.ObtenerRoles());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RolDto>> ObtenerPorId(int id)
    {
        return Ok(await _rolService.ObtenerPorId(id));
    }

    [HttpPut]
    public async Task<IActionResult> Actualizar(UpdateRolDto dto)
    {
        await _rolService.ActualizarRol(dto);
        return Ok(new { mensaje = "Rol actualizado correctamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _rolService.EliminarRol(id);
        return Ok(new { mensaje = "Rol eliminado correctamente" });
    }
}
