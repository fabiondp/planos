using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class PlanoCalculoUnidadesMap : IEntityTypeConfiguration<PlanoCalculoUnidadesEntity>
    {
        public void Configure(EntityTypeBuilder<PlanoCalculoUnidadesEntity> builder)
        {
            builder.ToTable("PlanoCalculoUnidades");

            builder.HasKey(bc => new { bc.PlanoId, bc.Id });

            builder.Property(u => u.Id).UseSqlServerIdentityColumn();

            builder.Property(u => u.QuantidadeMinima)
                    .IsRequired();

            builder.Property(u => u.QuantidadeMaxima)
                    .IsRequired();

            builder.Property(u => u.ValorPorUnidade)
                    .IsRequired();

            builder.HasOne(e => e.Plano)
                .WithMany(c => c.CalculoUnidades)
                .IsRequired();
        }
    }
}
