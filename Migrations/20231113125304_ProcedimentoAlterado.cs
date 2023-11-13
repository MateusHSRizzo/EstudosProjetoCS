using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudoProjetoCS.Migrations
{
    /// <inheritdoc />
    public partial class ProcedimentoAlterado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendente_Cliente_IdCliente",
                table: "Atendente");

            migrationBuilder.DropIndex(
                name: "IX_Atendente_IdCliente",
                table: "Atendente");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Atendente");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Procedimento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Registro",
                table: "Atendente",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimento_IdCliente",
                table: "Procedimento",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimento_Cliente_IdCliente",
                table: "Procedimento",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedimento_Cliente_IdCliente",
                table: "Procedimento");

            migrationBuilder.DropIndex(
                name: "IX_Procedimento_IdCliente",
                table: "Procedimento");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Procedimento");

            migrationBuilder.AlterColumn<string>(
                name: "Registro",
                table: "Atendente",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Atendente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atendente_IdCliente",
                table: "Atendente",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendente_Cliente_IdCliente",
                table: "Atendente",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
