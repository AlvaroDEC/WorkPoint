using ClaseEntityFramework.DTOs.Usuarios;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] //  Requiere autenticación JWT
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

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(object), 400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { success = false, message = "El ID debe ser mayor que 0" });
            }

            try
            {
                await _usuarioService.EliminarUsuarioAsync(id);
                return Ok(new { 
                    success = true, 
                    message = "Usuario eliminado correctamente" 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { 
                    success = false, 
                    message = ex.Message 
                });
            }
        }

        [HttpDelete("{id}/forzado")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(object), 400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> EliminarUsuarioForzado(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { success = false, message = "El ID debe ser mayor que 0" });
            }

            try
            {
                await _usuarioService.EliminarUsuarioForzadoAsync(id);
                return Ok(new { 
                    success = true, 
                    message = "Usuario eliminado físicamente (forzado)" 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { 
                    success = false, 
                    message = ex.Message 
                });
            }
        }
    }
}