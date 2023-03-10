using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SeagregonuevocampoalentidadcuentaysemapearonlosmovimientosalDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Accounts",
                newName: "InitialBalance");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Movements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "CurrentBalance",
                table: "Accounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "InitialBalance",
                table: "Accounts",
                newName: "Balance");
        }
    }
}
