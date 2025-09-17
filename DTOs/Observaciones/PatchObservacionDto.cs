using ClaseEntityFramework.DTOs.Evidencias;

namespace ClaseEntityFramework.DTOs.Observaciones
{
    public class PatchObservacionDto
    {
        public int? Id { get; set; }
        public string? Descripcion { get; set; }
        public int? CriterioDeGravedadId { get; set; }
        public int? ResponsableId { get; set; }
        public string? Estado { get; set; } 
        public List<PatchEvidenciaDto>? Evidencias { get; set; }
    }
}
