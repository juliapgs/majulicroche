using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace majulicroche.Data.Migrations
{
    /// <inheritdoc />
    public partial class cuponsestoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CupomId",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ControleEstoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUltimoReabastecimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleEstoque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cupom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupom", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_CupomId",
                table: "Vendas",
                column: "CupomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Cupom_CupomId",
                table: "Vendas",
                column: "CupomId",
                principalTable: "Cupom",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Cupom_CupomId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "ControleEstoque");

            migrationBuilder.DropTable(
                name: "Cupom");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_CupomId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "CupomId",
                table: "Vendas");
        }
    }
}
