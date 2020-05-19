using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanoCalculoFuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlanoId = table.Column<int>(nullable: false),
                    Uid = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    QuantidadeMinima = table.Column<int>(nullable: false),
                    QuantidadeMaxima = table.Column<int>(nullable: false),
                    ValorPorFuncionario = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoCalculoFuncionarios", x => new { x.PlanoId, x.Id });
                    table.UniqueConstraint("AK_PlanoCalculoFuncionarios_Uid", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_PlanoCalculoFuncionarios_Plano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Plano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanoCalculoFuncionarios");
        }
    }
}
