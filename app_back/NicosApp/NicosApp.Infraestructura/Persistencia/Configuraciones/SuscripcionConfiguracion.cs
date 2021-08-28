using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NicosApp.Core.Entidades;

namespace NicosApp.Infraestructura.Persistencia.Configuraciones
{
    public class SuscripcionConfiguracion : IEntityTypeConfiguration<Suscripcion>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Suscripcion> builder)
        {
            builder.ToTable("Suscripciones");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .HasColumnName("IdSuscripcion")
               .ValueGeneratedNever();



            builder.Property(e => e.FechaInicio)
              .HasDefaultValue(false)
               .HasColumnType("datetime")
              .HasColumnName("FechaInicio");



            builder.Property(e => e.FechaFin)
               .HasColumnType("datetime")
              .HasColumnName("FechaFin");


            builder.Property(e => e.EsVigente)
                .HasDefaultValue(false)
                .HasColumnName("EsVigente");



            builder.HasOne(d => d.ApplicationUser)
            .WithMany(p => p.Suscripciones)
            .HasForeignKey(d => d.ApplicationUserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Suscripcion_User");


                builder.HasOne(d => d.Paquete)
              .WithMany(p => p.Suscripciones)
              .HasForeignKey(d => d.PaqueteID)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_Suscripcion_Paquete");


                builder.HasOne(d => d.TipoSuscripcion)
            .WithMany(p => p.Suscripciones)
            .HasForeignKey(d => d.TipoSuscripcionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Suscripcion_TipoSuscripcion");


        }
    }
}
