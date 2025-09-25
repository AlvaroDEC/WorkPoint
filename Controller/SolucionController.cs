using Microsoft.AspNetCore.Mvc;
using ClaseEntityFramework.DTOs.Soluciones;
using ClaseEntityFramework.DTOs.Common;
using ClaseEntityFramework.Services.Interfaces;

namespace ClaseEntityFramework.Controllers
{
    /// <summary>
    /// Controlador para gestionar soluciones del sistema BPM
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SolucionController : ControllerBase
    {
        private readonly ISolucionService _solucionService;

        public SolucionController(ISolucionService solucionService)
        {
            _solucionService = solucionService;
        }

        /// <summary>
        /// Crear una nueva solución
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateSolucionDto dto)
        {
            await _solucionService.CrearSolucion(dto);
            return Ok(ApiResponse.SuccessResponse("Solución creada correctamente"));
        }

        /// <summary>
        /// Obtener todas las soluciones
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var soluciones = await _solucionService.ObtenerSoluciones();
            return Ok(ApiResponse<List<SolucionDto>>.SuccessResponse(soluciones, "Soluciones obtenidas correctamente"));
        }

        /// <summary>
        /// Obtener solución por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var solucion = await _solucionService.ObtenerPorId(id);
            return Ok(ApiResponse<SolucionDto>.SuccessResponse(solucion, "Solución obtenida correctamente"));
        }

        /// <summary>
        /// Actualizar una solución existente
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] UpdateSolucionDto dto)
        {
            await _solucionService.ActualizarSolucion(dto);
            return Ok(ApiResponse.SuccessResponse("Solución actualizada correctamente"));
        }

        /// <summary>
        /// Eliminar una solución
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _solucionService.EliminarSolucion(id);
            return Ok(ApiResponse.SuccessResponse("Solución eliminada correctamente"));
        }

        /// <summary>
        /// Obtener soluciones por observación
        /// </summary>
        [HttpGet("por-observacion/{observacionId}")]
        public async Task<IActionResult> ObtenerPorObservacion(int observacionId)
        {
            var soluciones = await _solucionService.ObtenerSolucionesPorObservacion(observacionId);
            return Ok(ApiResponse<List<SolucionDto>>.SuccessResponse(soluciones, "Soluciones obtenidas correctamente"));
        }

        /// <summary>
        /// Obtener soluciones por responsable
        /// </summary>
        [HttpGet("por-responsable/{responsableId}")]
        public async Task<IActionResult> ObtenerPorResponsable(int responsableId)
        {
            var soluciones = await _solucionService.ObtenerSolucionesPorResponsable(responsableId);
            return Ok(ApiResponse<List<SolucionDto>>.SuccessResponse(soluciones, "Soluciones obtenidas correctamente"));
        }

        /// <summary>
        /// Obtener soluciones para reportes con filtros
        /// </summary>
        [HttpGet("reportes")]
        public async Task<IActionResult> ObtenerParaReportes(
            [FromQuery] string? fechaDesde,
            [FromQuery] string? fechaHasta,
            [FromQuery] int pageSize = 1000)
        {
            try
            {
                var resultado = await _solucionService.ObtenerParaReportesAsync(
                    fechaDesde, fechaHasta, pageSize);
                
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse.ErrorResponse(ex.Message));
            }
        }
    }
}
