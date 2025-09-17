using ClaseEntityFramework.DTOs.Evidencias;

namespace ClaseEntityFramework.DTOs.Observaciones
{
    public class CreateObservacionConEvidenciaDto
    {
        public string Descripcion { get; set; }
        public int CriterioDeGravedadId { get; set; }
        public int ResponsableId { get; set; }

        public List<CreateEvidenciaDto> Evidencias { get; set; }
    }
}
