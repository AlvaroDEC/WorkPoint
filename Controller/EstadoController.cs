using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Estados;
using ClaseEntityFramework.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class EstadoController : ControllerBase
{
    private readonly IEstadoService _estadoService;

    public EstadoController(IEstadoService estadoService)
    {
        _estadoService = estadoService;
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CreateEstadoDto dto)
    {
        await _estadoService.CrearEstado(dto);
        return Ok(new { mensaje = "Estado creado correctamente" });
    }
    
    [HttpGet]
    public async Task<ActionResult<List<EstadoDto>>> Obtener()
    {
        return Ok(await _estadoService.ObtenerEstados());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EstadoDto>> ObtenerPorId(int id)
    {
        return Ok(await _estadoService.ObtenerPorId(id));
    }

    [HttpPatch]
    public async Task<IActionResult> Actualizar(UpdateEstadoDto dto)
    {
        await _estadoService.ActualizarEstado(dto);
        return Ok(new { mensaje = "Estado actualizado correctamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _estadoService.EliminarEstado(id);
        return Ok(new { mensaje = "Estado eliminado correctamente" });
    }
}
