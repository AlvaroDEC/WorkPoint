using ClaseEntityFramework.DTOs.Observaciones;

namespace ClaseEntityFramework.DTOs.Inspecciones
{
    public class PatchInspeccionDto
    {
        public int Id { get; set; }
        public int? AreaId { get; set; }
        public int? AuditorId { get; set; }
        public string? Estado { get; set; }
        public DateTime? Fecha { get; set; }
        public List<PatchObservacionDto>? Observaciones { get; set; }
    }
}
