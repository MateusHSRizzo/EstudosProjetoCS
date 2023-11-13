using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudoProjetoCS.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioModelAlter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Movimentacao_IdMovimentacao",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdMovimentacao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdMovimentacao",
                table: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMovimentacao",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdMovimentacao",
                table: "Usuario",
                column: "IdMovimentacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Movimentacao_IdMovimentacao",
                table: "Usuario",
                column: "IdMovimentacao",
                principalTable: "Movimentacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
