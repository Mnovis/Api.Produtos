using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Produtos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    ID_PRODUTO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.ID_PRODUTO);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_NOME",
                table: "PRODUTOS",
                column: "NOME",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTOS");
        }
    }
}
