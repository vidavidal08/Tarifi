using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NicosApp.Core.Entidades;

namespace NicosApp.Infraestructura.Persistencia.Configuraciones
{
    public class NicosConfiguracion : IEntityTypeConfiguration<Nico>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Nico> builder)
        {
            builder.ToTable("Nicos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
           .HasColumnName("IdNico")
            .ValueGeneratedNever();

            builder.Property(e => e.ClaveNICO)
            .IsRequired()
            .HasColumnName("ClaveNICO")
            .HasMaxLength(50);

            builder.Property(e => e.Descripcion)
           .IsRequired()
           .HasColumnName("Descripcion")
           .HasMaxLength(2000);

            builder.HasOne(d => d.FraccionArancelaria)
              .WithMany(p => p.Nicos)
              .HasForeignKey(d => d.IdFraccionArancelaria)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_Nico_NicoSub");
        }
    }
}
