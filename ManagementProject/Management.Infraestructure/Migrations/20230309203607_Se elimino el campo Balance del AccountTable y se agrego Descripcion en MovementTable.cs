using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SeeliminoelcampoBalancedelAccountTableyseagregoDescripcionenMovementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movements");

            migrationBuilder.AddColumn<double>(
                name: "CurrentBalance",
                table: "Accounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
