using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class PlanoMap : IEntityTypeConfiguration<PlanoEntity>
    {

        public void Configure(EntityTypeBuilder<PlanoEntity> builder)
        {
            builder.ToTable("Plano");

            builder.HasKey(p => p.Id);

            builder.Property(u => u.Id).UseSqlServerIdentityColumn();

            builder.Property(u => u.Titulo)
                    .IsRequired()
                    .HasMaxLength(300);

            builder.Property(u => u.Descricao)
                    .IsRequired()
                    .HasMaxLength(300);

            builder.HasMany(c => c.CalculoFuncionarios)
                    .WithOne(e => e.Plano);

            builder.HasMany(c => c.CalculoUnidades)
                   .WithOne(e => e.Plano);



            //HasRequired(p => p.Condominium)
            //  .WithMany()
            //  .HasForeignKey(p => p.CondominiumId);

        }
    }
}
