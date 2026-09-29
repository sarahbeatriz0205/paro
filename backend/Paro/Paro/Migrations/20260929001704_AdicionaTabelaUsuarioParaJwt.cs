using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paro.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaTabelaUsuarioParaJwt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rodadas_SalaId",
                table: "Rodadas",
                column: "SalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rodadas_Salas_SalaId",
                table: "Rodadas",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rodadas_Salas_SalaId",
                table: "Rodadas");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Rodadas_SalaId",
                table: "Rodadas");
        }
    }
}
