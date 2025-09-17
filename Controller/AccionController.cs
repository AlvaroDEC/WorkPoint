using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Acciones;
using ClaseEntityFramework.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class AccionController : ControllerBase
{
    private readonly IAccionService _accionService;

    public AccionController(IAccionService accionService)
    {
        _accionService = accionService;
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CreateAccionDto dto)
    {
        await _accionService.CrearAccion(dto);
        return Ok(new { mensaje = "Acción creada correctamente" });
    }
    
    [HttpGet]
    public async Task<ActionResult<List<AccionDto>>> Obtener()
    {
        return Ok(await _accionService.ObtenerAcciones());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AccionDto>> ObtenerPorId(int id)
    {
        return Ok(await _accionService.ObtenerPorId(id));
    }

    [HttpPatch]
    public async Task<IActionResult> Actualizar(UpdateAccionDto dto)
    {
        await _accionService.ActualizarAccion(dto);
        return Ok(new { mensaje = "Acción actualizada correctamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _accionService.EliminarAccion(id);
        return Ok(new { mensaje = "Acción eliminada correctamente" });
    }
}
