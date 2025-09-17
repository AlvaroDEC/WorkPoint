using ClaseEntityFramework.DTOs.Usuarios;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> CrearUsuario(CreateUsuarioDto dto)
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
                return BadRequest(new { success = false, message = "Los datos del usuario son requeridos" });
            }

            var usuario = await _usuarioService.CrearUsuarioAsync(dto);
            return CreatedAtAction(nameof(ObtenerUsuarios), new { id = usuario.Id }, usuario);
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDto>>> ObtenerUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> ObtenerPorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { success = false, message = "El ID debe ser mayor que 0" });
            }

            var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(id);
            
            if (usuario == null)
                return NotFound(new { mensaje = "Usuario no encontrado" });

            return Ok(usuario);  
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<UsuarioDto>> PatchUsuario(int id, UpdateUsuarioDto dto)
        {
            if (id <= 0)
            {
                return BadRequest(new { success = false, message = "El ID debe ser mayor que 0" });
            }

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
                return BadRequest(new { success = false, message = "Los datos del usuario son requeridos" });
            }

            try
            {
                var usuario = await _usuarioService.ActualizarParcialmenteUsuarioAsync(id, dto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }
    }
}