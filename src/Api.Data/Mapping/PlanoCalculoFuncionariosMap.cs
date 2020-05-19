using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class PlanoCalculoFuncionariosMap : IEntityTypeConfiguration<PlanoCalculoFuncionariosEntity>
    {
        public void Configure(EntityTypeBuilder<PlanoCalculoFuncionariosEntity> builder)
        {
            builder.ToTable("PlanoCalculoFuncionarios");

            builder.HasKey(bc => new { bc.PlanoId, bc.Id });

            builder.Property(u => u.Id).UseSqlServerIdentityColumn();

            builder.Property(u => u.QuantidadeMinima).IsRequired();

            builder.Property(u => u.QuantidadeMaxima).IsRequired();

            builder.Property(u => u.ValorPorFuncionario).IsRequired();

            builder.HasOne(e => e.Plano).WithMany(c => c.CalculoFuncionarios).IsRequired();
        }
    }
}
