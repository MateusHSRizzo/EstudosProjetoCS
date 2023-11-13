using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudoProjetoCS.Migrations
{
    /// <inheritdoc />
    public partial class MovimentacaoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacao_Usuario_IdUsuario",
                table: "Movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacao_IdUsuario",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Movimentacao");

            migrationBuilder.AddColumn<string>(
                name: "usuario",
                table: "Movimentacao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuario",
                table: "Movimentacao");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Movimentacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_IdUsuario",
                table: "Movimentacao",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacao_Usuario_IdUsuario",
                table: "Movimentacao",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
