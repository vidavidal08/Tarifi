using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NicosApp.Core.Entidades;

namespace NicosApp.Infraestructura.Persistencia.Configuraciones
{
    public class PermisoFraccionConfiguracion : IEntityTypeConfiguration<PermisoFraccion>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<PermisoFraccion> builder)
        {
            builder.ToTable("PermisosFraccion");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .HasColumnName("IdPermisoFraccion")
               .ValueGeneratedNever();

            builder.Property(e => e.Acotacion)
             .HasColumnName("Acotacion")
             .HasMaxLength(5000);

            builder.Property(e => e.Permiso)
             .HasColumnName("Permiso")
             .HasMaxLength(5000);

            builder.HasOne(d => d.FraccionArancelaria)
              .WithMany(p => p.PermisosFraccion)
              .HasForeignKey(d => d.IdFraccionArancelaria)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_FraccionArancelaria_PermisoFraccion");
        }
    }
}
