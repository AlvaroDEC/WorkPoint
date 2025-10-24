using Microsoft.EntityFrameworkCore;
using ClaseEntityFramework.Models;

namespace ClaseEntityFramework.Data
{
    public class AppContexts : DbContext
    {
        public AppContexts(DbContextOptions<AppContexts> options) : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<AsignacionRoles> AsignacionesRoles { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Inspeccion> Inspecciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CriterioDeGravedad> CriteriosDeGravedad { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Solucion> Soluciones { get; set; }
        public DbSet<Evidencia> Evidencias { get; set; }
        public DbSet<EvidenciaSolucion> EvidenciasSolucion { get; set; }
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<Permiso> Permisos { get; set; }

        
    }

}