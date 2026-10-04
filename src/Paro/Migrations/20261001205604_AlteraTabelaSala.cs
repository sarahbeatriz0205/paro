using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paro.Migrations
{
    /// <inheritdoc />
    public partial class AlteraTabelaSala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Salas_SalaId",
                table: "Jogadores");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Jogadores",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Jogadores",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Salas_SalaId",
                table: "Jogadores",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Salas_SalaId",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Jogadores");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Jogadores",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Salas_SalaId",
                table: "Jogadores",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id");
        }
    }
}
