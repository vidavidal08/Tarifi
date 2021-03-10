using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NicosApp.Core.Entidades;
using System;
using System.Collections.Generic;
/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 20-02-2021
/// </summary>
namespace NicosApp.Infraestructura.Persistencia.Configuraciones
{
    public class FraccionArancelariaConfiguracion : IEntityTypeConfiguration<FraccionArancelaria>
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<FraccionArancelaria> builder)
        {
            builder.ToTable("FraccionArancelarias");


            builder.HasKey(e => e.Id);


            builder.Property(e => e.Id)
               .HasColumnName("IdFraccionArancelaria")
               .ValueGeneratedNever();


            builder.Property(e => e.ClaveFraccion)
             .IsRequired()
             .HasColumnName("ClaveFraccion")
             .HasMaxLength(50);



            builder.Property(e => e.Descripcion)
            .HasColumnName("Descripcion")
            .HasMaxLength(1000);


            builder.Property(e => e.UnidadMedida)
           .HasColumnName("UnidadMedida")
           .HasMaxLength(50);



            builder.Property(e => e.IGI)
           .HasColumnName("IGI")
           .HasMaxLength(50);



            builder.Property(e => e.IGE)
           .HasColumnName("IGE")
           .HasMaxLength(50);




            // Seed
            builder.HasData(new List<FraccionArancelaria> {
                new FraccionArancelaria
                {
                    Id = Guid.Parse("6672E891-0D94-4620-B38A-DBC5B02DA9F7"),
                    ClaveFraccion = "0101.21.01"
                },
                new FraccionArancelaria
                {
                    Id = Guid.Parse("CC9D7ECA-6428-4E6D-B40B-2C8D93AB7347"),
                    ClaveFraccion = "0101.29.02"
                }
            });

        }
    }
}
