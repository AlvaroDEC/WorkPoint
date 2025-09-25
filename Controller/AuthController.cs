using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Auth;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            return Ok(result);
        }

        [HttpGet("me/permissions")]
        public async Task<IActionResult> ObtenerMisPermisos()
        {
            try
            {
                // TODO: Implementar obtención de permisos del usuario autenticado
                // Por ahora retornamos un ejemplo
                var permisos = new List<string>
                {
                    "USUARIOS_VER", "USUARIOS_CREAR", "ROLES_VER", "INSPECCIONES_VER"
                };

                return Ok(new
                {
                    success = true,
                    permisos = permisos,
                    total = permisos.Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Error al obtener permisos",
                    error = ex.Message
                });
            }
        }
    }
}
