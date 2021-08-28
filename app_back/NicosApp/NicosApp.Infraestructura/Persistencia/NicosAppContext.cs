using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NicosApp.Core.Entidades;
using System.Reflection;
/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 20-02-2021
/// </summary>
namespace NicosApp.Infraestructura.Data
{
    public class NicosAppContext : IdentityDbContext<ApplicationUser>
    {
        public NicosAppContext(DbContextOptions<NicosAppContext> options)
           : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public virtual DbSet<Nico> Nicos { get; set; }
        public virtual DbSet<FraccionArancelaria> FraccionArancelarias { get; set; }
        public virtual DbSet<Paquete> Paquetes { get; set; }
        public virtual DbSet<PermisoFraccion> PermisoFraccion { get; set; }
        public virtual DbSet<Suscripcion> Suscripcion { get; set; }
        public virtual DbSet<TipoSuscripcion> TipoSuscripcion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
