namespace ClaseEntityFramework.DTOs.Soluciones
{
    public class SolucionDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int ObservacionId { get; set; }
        public string ObservacionDescripcion { get; set; }
        public int ResponsableId { get; set; }
        public string ResponsableNombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaImplementacion { get; set; }
        public int TotalEvidencias { get; set; }
    }
}