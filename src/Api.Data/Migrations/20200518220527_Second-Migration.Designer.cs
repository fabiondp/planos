﻿// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200518220527_Second-Migration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Domain.Entities.ChaveAPIEntity", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCriacao");

                    b.Property<string>("Login");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.HasKey("Uid");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasFilter("[Login] IS NOT NULL");

                    b.ToTable("ChaveAPI");
                });

            modelBuilder.Entity("Domain.Entities.PlanoCalculoFuncionariosEntity", b =>
                {
                    b.Property<int>("PlanoId");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCriacao");

                    b.Property<int>("QuantidadeMaxima");

                    b.Property<int>("QuantidadeMinima");

                    b.Property<Guid>("Uid");

                    b.Property<float>("ValorPorFuncionario");

                    b.HasKey("PlanoId", "Id");

                    b.HasAlternateKey("Uid");

                    b.ToTable("PlanoCalculoFuncionarios");
                });

            modelBuilder.Entity("Domain.Entities.PlanoCalculoUnidadesEntity", b =>
                {
                    b.Property<int>("PlanoId");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCriacao");

                    b.Property<int>("QuantidadeMaxima");

                    b.Property<int>("QuantidadeMinima");

                    b.Property<Guid>("Uid");

                    b.Property<float>("ValorPorUnidade");

                    b.HasKey("PlanoId", "Id");

                    b.HasAlternateKey("Uid");

                    b.ToTable("PlanoCalculoUnidades");
                });

            modelBuilder.Entity("Domain.Entities.PlanoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCriacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<Guid>("Uid");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uid");

                    b.ToTable("Plano");
                });

            modelBuilder.Entity("Domain.Entities.PlanoServicosEntity", b =>
                {
                    b.Property<int>("PlanoId");

                    b.Property<int>("ServicoId");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCriacao");

                    b.Property<Guid>("Uid");

                    b.HasKey("PlanoId", "ServicoId");

                    b.HasAlternateKey("Uid");

                    b.HasIndex("ServicoId");

                    b.ToTable("PlanoServicos");
                });

            modelBuilder.Entity("Domain.Entities.ServicosEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCriacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<Guid>("Uid");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uid");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Domain.Entities.PlanoCalculoFuncionariosEntity", b =>
                {
                    b.HasOne("Domain.Entities.PlanoEntity", "Plano")
                        .WithMany("CalculoFuncionarios")
                        .HasForeignKey("PlanoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.PlanoCalculoUnidadesEntity", b =>
                {
                    b.HasOne("Domain.Entities.PlanoEntity", "Plano")
                        .WithMany("CalculoUnidades")
                        .HasForeignKey("PlanoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.PlanoServicosEntity", b =>
                {
                    b.HasOne("Domain.Entities.PlanoEntity", "Plano")
                        .WithMany("Servicos")
                        .HasForeignKey("PlanoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.ServicosEntity", "Servico")
                        .WithMany("Planos")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
