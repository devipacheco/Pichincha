using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Restructuraciondetablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Movements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Movements",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
