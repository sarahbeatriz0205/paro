using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paro.Migrations
{
    /// <inheritdoc />
    public partial class MudaRodada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rodadas_Salas_SalaId",
                table: "Rodadas");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Rodadas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Rodadas_Salas_SalaId",
                table: "Rodadas",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rodadas_Salas_SalaId",
                table: "Rodadas");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Rodadas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rodadas_Salas_SalaId",
                table: "Rodadas",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
