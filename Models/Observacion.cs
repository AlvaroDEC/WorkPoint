using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Models
{
    public class Observacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [ForeignKey(nameof(CriterioDeGravedad))]
        public int CriterioDeGravedadId { get; set; }
        public CriterioDeGravedad CriterioDeGravedad { get; set; }

        [Required]
        [ForeignKey(nameof(Categoria))]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Required]
        [ForeignKey(nameof(Estado))]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }


        [Column(TypeName = "timestamp with time zone")]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // FK: Inspección
        [Required]
        [ForeignKey(nameof(Inspeccion))]
        public int InspeccionId { get; set; }
        public Inspeccion Inspeccion { get; set; }

        // FK: Responsable (usuario que dará solución)
        [Required]
        [ForeignKey(nameof(Responsable))]
        public int ResponsableId { get; set; }
        public Usuario Responsable { get; set; }

        // Relaciones
        public ICollection<Evidencia> Evidencias { get; set; }
        public ICollection<Solucion> Soluciones { get; set; }
        public ICollection<Seguimiento> Seguimientos { get; set; }
    }
}
