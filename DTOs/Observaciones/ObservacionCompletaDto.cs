using ClaseEntityFramework.DTOs.CriteriosDeGravedad;
using ClaseEntityFramework.DTOs.Categorias;
using ClaseEntityFramework.DTOs.Estados;
using ClaseEntityFramework.DTOs.Inspecciones;
using ClaseEntityFramework.DTOs.Usuarios;
using ClaseEntityFramework.DTOs.Evidencias;
using ClaseEntityFramework.DTOs.Soluciones;
using ClaseEntityFramework.DTOs.Seguimientos;

namespace ClaseEntityFramework.DTOs.Observaciones
{
    /// <summary>
    /// DTO para mostrar una observación completa con todas sus relaciones
    /// </summary>
    public class ObservacionCompletaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        
        // Criterio de gravedad completo
        public CriterioDto CriterioDeGravedad { get; set; }
        
        // Categoría completa
        public CategoriaDto Categoria { get; set; }
        
        // Estado completo
        public EstadoDto Estado { get; set; }
        
        
        // Información de la inspección
        public InspeccionListaDto Inspeccion { get; set; }
        
        // Información del responsable
        public UsuarioDto Responsable { get; set; }
        
        // Evidencias
        public List<EvidenciaDto> Evidencias { get; set; }
        
        // Soluciones
        public List<SolucionDto> Soluciones { get; set; }
        
        // Seguimientos
        public List<SeguimientoDto> Seguimientos { get; set; }
    }
}
