using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NicosApp.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Infraestructura.Persistencia.Configuraciones
{
    public class TipoSuscripcionConfiguracion : IEntityTypeConfiguration<TipoSuscripcion>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<TipoSuscripcion> builder)
        {

            builder.ToTable("TipoSuscripcion");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
           .HasColumnName("IdTipoSuscripcion")
            .ValueGeneratedNever();


            builder.Property(e => e.Nombre)
           .HasColumnName("Nombre")
           .HasMaxLength(100);


            builder.Property(e => e.Descripcion)
              .HasColumnName("Descripcion")
              .HasMaxLength(1000);



            builder.Property(e => e.DiasVigencia)
             .HasColumnName("DiasVigencia");


            builder.Property(e => e.Code)
           .HasColumnName("Code")
           .HasMaxLength(50);



            builder.Property(e => e.Reelegible)
                .HasDefaultValue(false)
                .HasColumnName("Reelegible");


            builder.Property(e => e.Precio)
                .HasPrecision(18, 6)
            .HasColumnName("Precio");




        }
    }
}
