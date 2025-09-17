using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Problemas;
using ClaseEntityFramework.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ProblemaController : ControllerBase
{
    private readonly IProblemaService _problemaService;

    public ProblemaController(IProblemaService problemaService)
    {
        _problemaService = problemaService;
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CreateProblemaDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { 
                success = false, 
                message = "Datos de entrada inválidos", 
                errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) 
            });
        }

        if (dto == null)
        {
            return BadRequest(new { success = false, message = "Los datos del problema son requeridos" });
        }

        await _problemaService.CrearProblema(dto);
        return Ok(new { mensaje = "Problema creado correctamente" });
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ProblemaDto>>> Obtener()
    {
        return Ok(await _problemaService.ObtenerProblemas());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProblemaDto>> ObtenerPorId(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new { success = false, message = "El ID debe ser mayor que 0" });
        }

        return Ok(await _problemaService.ObtenerPorId(id));
    }

    [HttpPatch]
    public async Task<IActionResult> Actualizar(UpdateProblemaDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { 
                success = false, 
                message = "Datos de entrada inválidos", 
                errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) 
            });
        }

        if (dto == null)
        {
            return BadRequest(new { success = false, message = "Los datos del problema son requeridos" });
        }

        if (dto.Id <= 0)
        {
            return BadRequest(new { success = false, message = "El ID debe ser mayor que 0" });
        }

        await _problemaService.ActualizarProblema(dto);
        return Ok(new { mensaje = "Problema actualizado correctamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new { success = false, message = "El ID debe ser mayor que 0" });
        }

        await _problemaService.EliminarProblema(id);
        return Ok(new { mensaje = "Problema eliminado correctamente" });
    }
}
