using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class ServicosMap : IEntityTypeConfiguration<ServicosEntity>
    {
        public void Configure(EntityTypeBuilder<ServicosEntity> builder)
        {
            builder.ToTable("Servicos");

            builder.HasKey(p => p.Id);

            builder.Property(u => u.Id).UseSqlServerIdentityColumn();

            builder.Property(u => u.Descricao)
                    .IsRequired()
                    .HasMaxLength(300);

        }
    }
}
