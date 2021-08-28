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
    public class PaqueteConfiguracion : IEntityTypeConfiguration<Paquete>
    {



        public void Configure(EntityTypeBuilder<Paquete> builder)
        {
            builder.ToTable("Paquetes");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .HasColumnName("IdPaquete")
               .ValueGeneratedNever();


            builder.Property(e => e.Nombre)
           .HasColumnName("Nombre")
           .HasMaxLength(100);


            builder.Property(e => e.Descripcion)
              .HasColumnName("Descripcion")
              .HasMaxLength(1000);
        }
    }
}
