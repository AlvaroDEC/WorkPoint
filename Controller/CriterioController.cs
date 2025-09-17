using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.CriteriosDeGravedad;
using ClaseEntityFramework.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class CriterioController : ControllerBase
{
    private readonly ICriterioService _criterioService;

    public CriterioController(ICriterioService criterioService)
    {
        _criterioService = criterioService;
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CreateCriterioDto dto)
    {
        await _criterioService.CrearCriterio(dto);
        return Ok(new { mensaje = "Criterio creado correctamente" });
    }
    
    [HttpGet]
    public async Task<ActionResult<List<CriterioDto>>> Obtener()
    {
        return Ok(await _criterioService.ObtenerCriterios());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CriterioDto>> ObtenerPorId(int id)
    {
        return Ok(await _criterioService.ObtenerPorId(id));
    }

    [HttpPatch]
    public async Task<IActionResult> Actualizar(UpdateCriterioDto dto)
    {
        await _criterioService.ActualizarCriterio(dto);
        return Ok(new { mensaje = "Criterio actualizado correctamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _criterioService.EliminarCriterio(id);
        return Ok(new { mensaje = "Criterio eliminado correctamente" });
    }
}