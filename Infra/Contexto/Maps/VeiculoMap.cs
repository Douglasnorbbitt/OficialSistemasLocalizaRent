using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Contexto.Maps
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Marca).IsRequired().HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.Data).IsRequired().HasMaxLength(10).HasColumnType("varchar(10)");
            builder.Property(x => x.Quilometragem).IsRequired().HasMaxLength(15).HasColumnType("varchar(15)");
        }
    }
}
