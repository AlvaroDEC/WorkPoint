using ClaseEntityFramework.DTOs.Observaciones;

namespace ClaseEntityFramework.DTOs.Inspecciones
{
    public class CreateInspeccionDto
    {
        public int AuditorId { get; set; }
        public int AreaId { get; set; }
        public List<CreateObservacionConEvidenciaDto> Observaciones { get; set; }
    }
}