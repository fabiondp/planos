using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ChaveAPIMap : IEntityTypeConfiguration<ChaveAPIEntity>
    {
        public void Configure(EntityTypeBuilder<ChaveAPIEntity> builder)
        {
            builder.ToTable("ChaveAPI");

            builder.HasKey(p=> p.Uid);

            builder.HasIndex(p=> p.Login)
                    .IsUnique();

            builder.Property(u=> u.Senha)
                    .IsRequired()
                    .HasMaxLength(12);

        }
    }
}