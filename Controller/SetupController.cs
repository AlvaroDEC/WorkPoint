using ClaseEntityFramework.Services.Interfaces;
using ClaseEntityFramework.DTOs.Acciones;
using ClaseEntityFramework.DTOs.Common;
using ClaseEntityFramework.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ClaseEntityFramework.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetupController : ControllerBase
    {
        private readonly IAccionService _accionService;
        private readonly ILogger<SetupController> _logger;

        public SetupController(IAccionService accionService, ILogger<SetupController> logger)
        {
            _accionService = accionService;
            _logger = logger;
        }

        /// <summary>
        /// Inicializa todas las acciones atómicas del sistema
        /// </summary>
        [HttpPost("inicializar-acciones")]
        public async Task<IActionResult> InicializarAcciones()
        {
            try
            {
                _logger.LogInformation("Iniciando inicialización de acciones del sistema");
                
                var acciones = SystemActions.GetAllActions();
                var accionesCreadas = new List<string>();
                var accionesExistentes = new List<string>();

                foreach (var nombreAccion in acciones)
                {
                    try
                    {
                        var dto = new CreateAccionDto { Nombre = nombreAccion };
                        await _accionService.CrearAccion(dto);
                        accionesCreadas.Add(nombreAccion);
                        _logger.LogDebug("Acción creada: {Accion}", nombreAccion);
                    }
                    catch (Exception ex)
                    {
                        accionesExistentes.Add(nombreAccion);
                        _logger.LogWarning("Acción ya existe: {Accion}. Error: {Error}", nombreAccion, ex.Message);
                    }
                }

                var result = new
                {
                    accionesCreadas,
                    accionesExistentes,
                    totalCreadas = accionesCreadas.Count,
                    totalExistentes = accionesExistentes.Count
                };

                _logger.LogInformation("Inicialización completada. Creadas: {Creadas}, Existentes: {Existentes}", 
                    accionesCreadas.Count, accionesExistentes.Count);

                return Ok(ApiResponse<object>.SuccessResponse(result, "Inicialización de acciones atómicas completada"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al inicializar acciones del sistema");
                return BadRequest(ApiResponse.ErrorResponse(ex.Message, "Error al inicializar acciones"));
            }
        }

        /// <summary>
        /// Obtiene todas las acciones disponibles agrupadas por módulo
        /// </summary>
        [HttpGet("acciones-agrupadas")]
        public async Task<IActionResult> ObtenerAccionesAgrupadas()
        {
            try
            {
                _logger.LogInformation("Obteniendo acciones agrupadas por módulo");
                
                var acciones = await _accionService.ObtenerAcciones();
                
                var accionesAgrupadas = acciones
                    .GroupBy(a => ExtractModuleFromAction(a.Nombre))
                    .Select(g => new
                    {
                        Modulo = g.Key,
                        Acciones = g.Select(a => new
                        {
                            a.Id,
                            a.Nombre,
                            Operacion = ExtractOperationFromAction(a.Nombre)
                        }).ToList()
                    })
                    .ToList();

                var result = new
                {
                    modulos = accionesAgrupadas,
                    totalAcciones = acciones.Count
                };

                _logger.LogInformation("Acciones agrupadas obtenidas: {Total} acciones en {Modulos} módulos", 
                    acciones.Count, accionesAgrupadas.Count);

                return Ok(ApiResponse<object>.SuccessResponse(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener acciones agrupadas");
                return BadRequest(ApiResponse.ErrorResponse(ex.Message, "Error al obtener acciones agrupadas"));
            }
        }

        /// <summary>
        /// Obtiene todas las acciones disponibles
        /// </summary>
        [HttpGet("acciones-disponibles")]
        public async Task<IActionResult> ObtenerAccionesDisponibles()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las acciones disponibles");
                
                var acciones = await _accionService.ObtenerAcciones();
                
                var result = new
                {
                    acciones,
                    total = acciones.Count
                };

                _logger.LogInformation("Acciones obtenidas: {Total} acciones", acciones.Count);
                
                return Ok(ApiResponse<object>.SuccessResponse(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener acciones disponibles");
                return BadRequest(ApiResponse.ErrorResponse(ex.Message, "Error al obtener acciones"));
            }
        }

        /// <summary>
        /// Limpia acciones duplicadas en la base de datos
        /// </summary>
        [HttpPost("limpiar-acciones-duplicadas")]
        public async Task<IActionResult> LimpiarAccionesDuplicadas()
        {
            try
            {
                _logger.LogInformation("Iniciando limpieza de acciones duplicadas");
                
                var acciones = await _accionService.ObtenerAcciones();
                
                // Agrupar por nombre y eliminar duplicados
                var accionesUnicas = acciones
                    .GroupBy(a => a.Nombre)
                    .Select(g => g.First())
                    .ToList();

                var duplicadosEliminados = acciones.Count - accionesUnicas.Count;
                
                if (duplicadosEliminados > 0)
                {
                    // Eliminar todas las acciones actuales
                    await _accionService.EliminarTodasLasAcciones();
                    
                    // Recrear solo las acciones únicas
                    var accionesRecreadas = new List<string>();
                    foreach (var accion in accionesUnicas)
                    {
                        var dto = new CreateAccionDto { Nombre = accion.Nombre };
                        await _accionService.CrearAccion(dto);
                        accionesRecreadas.Add(accion.Nombre);
                    }

                    var result = new
                    {
                        accionesEliminadas = duplicadosEliminados,
                        accionesRecreadas = accionesRecreadas.Count,
                        acciones = accionesRecreadas
                    };

                    _logger.LogInformation("Limpieza completada. Eliminados: {Eliminados}, Recreados: {Recreados}", 
                        duplicadosEliminados, accionesRecreadas.Count);

                    return Ok(ApiResponse<object>.SuccessResponse(result, "Acciones duplicadas eliminadas exitosamente"));
                }
                else
                {
                    _logger.LogInformation("No se encontraron acciones duplicadas");
                    return Ok(ApiResponse.SuccessResponse("No se encontraron acciones duplicadas"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al limpiar acciones duplicadas");
                return BadRequest(ApiResponse.ErrorResponse(ex.Message, "Error al limpiar acciones duplicadas"));
            }
        }

        /// <summary>
        /// Obtiene la matriz de permisos para un rol específico
        /// </summary>
        [HttpGet("matriz-permisos/{rolId}")]
        public async Task<IActionResult> ObtenerMatrizPermisos(int rolId)
        {
            try
            {
                _logger.LogInformation("Obteniendo matriz de permisos para rol {RolId}", rolId);
                
                // TODO: Implementar obtención de matriz con flags por rol
                // Por ahora retornamos un ejemplo
                var matriz = new
                {
                    rolId,
                    modulos = new[]
                    {
                        new
                        {
                            modulo = "USUARIOS",
                            acciones = new[]
                            {
                                new { id = 1, nombre = SystemActions.USUARIOS_CREAR, asignado = true },
                                new { id = 2, nombre = SystemActions.USUARIOS_EDITAR, asignado = false },
                                new { id = 3, nombre = SystemActions.USUARIOS_ELIMINAR, asignado = true },
                                new { id = 4, nombre = SystemActions.USUARIOS_VER, asignado = true }
                            }
                        },
                        new
                        {
                            modulo = "ROLES",
                            acciones = new[]
                            {
                                new { id = 5, nombre = SystemActions.ROLES_CREAR, asignado = false },
                                new { id = 6, nombre = SystemActions.ROLES_EDITAR, asignado = true },
                                new { id = 7, nombre = SystemActions.ROLES_ELIMINAR, asignado = false },
                                new { id = 8, nombre = SystemActions.ROLES_VER, asignado = true }
                            }
                        }
                    }
                };

                _logger.LogInformation("Matriz de permisos obtenida para rol {RolId}", rolId);
                
                return Ok(ApiResponse<object>.SuccessResponse(matriz));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener matriz de permisos para rol {RolId}", rolId);
                return BadRequest(ApiResponse.ErrorResponse(ex.Message, "Error al obtener matriz de permisos"));
            }
        }

        #region Private Helper Methods

        /// <summary>
        /// Extrae el módulo de una acción (parte antes del guión bajo)
        /// </summary>
        private static string ExtractModuleFromAction(string actionName)
        {
            var parts = actionName.Split('_');
            return parts.Length > 0 ? parts[0] : actionName;
        }

        /// <summary>
        /// Extrae la operación de una acción (parte después del guión bajo)
        /// </summary>
        private static string ExtractOperationFromAction(string actionName)
        {
            var parts = actionName.Split('_');
            return parts.Length > 1 ? parts[1] : actionName;
        }

        #endregion
    }
}
