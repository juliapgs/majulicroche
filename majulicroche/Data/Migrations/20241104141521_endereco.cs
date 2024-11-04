using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace majulicroche.Data.Migrations
{
    /// <inheritdoc />
    public partial class endereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Fornecedor",
                newName: "Endereco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Fornecedor",
                newName: "Telefone");
        }
    }
}
