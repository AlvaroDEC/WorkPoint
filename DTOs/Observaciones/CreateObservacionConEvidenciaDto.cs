using ClaseEntityFramework.DTOs.Evidencias;

namespace ClaseEntityFramework.DTOs.Observaciones
{
    public class CreateObservacionConEvidenciaDto
    {
        public string Descripcion { get; set; }
        public int CriterioDeGravedadId { get; set; }
        public int CategoriaId { get; set; }
        public int ResponsableId { get; set; }

        public List<CreateEvidenciaInspeccionDto> Evidencias { get; set; }
    }
}
