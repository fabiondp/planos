using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class PlanoServicosMap : IEntityTypeConfiguration<PlanoServicosEntity>
    {
        public void Configure(EntityTypeBuilder<PlanoServicosEntity> builder)
        {
            builder.ToTable("PlanoServicos");

            builder.HasKey(bc => new { bc.PlanoId, bc.ServicoId });

            builder.HasOne(bc => bc.Plano)
                .WithMany(b => b.Servicos)
                .HasForeignKey(bc => bc.PlanoId);

            builder.HasOne(bc => bc.Servico)
                .WithMany(b => b.Planos)
                .HasForeignKey(bc => bc.ServicoId);
        }
    }
}
