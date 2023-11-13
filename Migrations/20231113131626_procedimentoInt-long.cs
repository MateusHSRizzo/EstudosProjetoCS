using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudoProjetoCS.Migrations
{
    /// <inheritdoc />
    public partial class procedimentoIntlong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Codigo_Procedimento",
                table: "Procedimento",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Codigo_Procedimento",
                table: "Procedimento",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
