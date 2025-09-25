using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Permisos;
using ClaseEntityFramework.DTOs.Common;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisoController : ControllerBase
    {
        private readonly IPermisoService _permisoService;
        private readonly ILogger<PermisoController> _logger;

        public PermisoController(IPermisoService permisoService, ILogger<PermisoController> logger)
        {
            _permisoService = permisoService;
            _logger = logger;
        }

        /// <summary>
        /// Crea un nuevo permiso
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreatePermisoDto dto)
        {
            try
            {
                _logger.LogInformation("Creando permiso para rol {RolId} y acción {AccionId}", dto.RolId, dto.AccionId);
                
                await _permisoService.CrearPermiso(dto);
                
                _logger.LogInformation("Permiso creado exitosamente");
                return Ok(ApiResponse.SuccessResponse("Permiso creado correctamente"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear permiso");
                return BadRequest(ApiResponse.ErrorResponse(ex.Message, "Error al crear permiso"));
            }
        }

        /// <summary>
        /// Obtiene todos los permisos de un rol específico
        /// </summary>
        [HttpGet("rol/{rolId}")]
        public async Task<IActionResult> ObtenerPermisosPorRol(int rolId)
        {
            try
            {
                _logger.LogInformation("Obteniendo permisos para rol {RolId}", rolId);

                if (rolId <= 0)
                {
                    _logger.LogWarning("RolId inválido: {RolId}", rolId);
                    return BadRequest(ApiResponse.ErrorResponse("El ID del rol debe ser mayor que 0"));
                }

                var permisos = await _permisoService.ObtenerPermisosPorRol(rolId);
                
                var result = new
                {
                    permisos,
                    total = permisos.Count,
                    rolId
                };

                _logger.LogInformation("Permisos obtenidos para rol {RolId}: {Total} permisos", rolId, permisos.Count);
                
                return Ok(ApiResponse<object>.SuccessResponse(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener permisos para rol {RolId}", rolId);
                return BadRequest(ApiResponse.ErrorResponse(ex.Message, "Error al obtener permisos"));
            }
        }

        [HttpPost("rol/{rolId}/asignar")]
        public async Task<IActionResult> AsignarPermisosARol(int rolId, [FromBody] List<int> accionIds)
        {
            try
            {
                // Logging detallado
                Console.WriteLine($"=== ASIGNAR PERMISOS ===");
                Console.WriteLine($"RolId: {rolId}");
                Console.WriteLine($"AccionIds recibidos: [{string.Join(", ", accionIds)}]");
                Console.WriteLine($"Cantidad de acciones: {accionIds?.Count ?? 0}");

                // Validaciones
                if (accionIds == null || !accionIds.Any())
                {
                    Console.WriteLine("ERROR: Lista de acciones vacía o nula");
                    return BadRequest(new { 
                        success = false, 
                        message = "Debe proporcionar al menos una acción",
                        rolId = rolId,
                        accionIds = accionIds
                    });
                }

                if (rolId <= 0)
                {
                    Console.WriteLine("ERROR: RolId inválido");
                    return BadRequest(new { 
                        success = false, 
                        message = "El ID del rol debe ser mayor que 0",
                        rolId = rolId
                    });
                }

                // Verificar que todas las acciones sean válidas
                var accionesInvalidas = accionIds.Where(id => id <= 0).ToList();
                if (accionesInvalidas.Any())
                {
                    Console.WriteLine($"ERROR: Acciones inválidas: [{string.Join(", ", accionesInvalidas)}]");
                    return BadRequest(new { 
                        success = false, 
                        message = "Algunas acciones tienen IDs inválidos",
                        accionesInvalidas = accionesInvalidas
                    });
                }

                await _permisoService.AsignarPermisosARol(rolId, accionIds);
                
                Console.WriteLine("SUCCESS: Permisos asignados correctamente");
                return Ok(new { 
                    success = true,
                    mensaje = "Permisos asignados correctamente",
                    rolId = rolId,
                    accionesAsignadas = accionIds.Count
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                
                return BadRequest(new { 
                    success = false, 
                    message = "Error interno del servidor",
                    error = ex.Message,
                    rolId = rolId,
                    accionIds = accionIds
                });
            }
        }

        [HttpDelete("rol/{rolId}/accion/{accionId}")]
        public async Task<IActionResult> EliminarPermiso(int rolId, int accionId)
        {
            await _permisoService.EliminarPermiso(rolId, accionId);
            return Ok(new { mensaje = "Permiso eliminado correctamente" });
        }
    }
}
