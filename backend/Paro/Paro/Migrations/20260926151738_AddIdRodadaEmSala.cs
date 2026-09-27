using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paro.Migrations
{
    /// <inheritdoc />
    public partial class AddIdRodadaEmSala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Salas");

            migrationBuilder.AddColumn<int>(
                name: "IdRodada",
                table: "Salas",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRodada",
                table: "Salas");

            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Salas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
