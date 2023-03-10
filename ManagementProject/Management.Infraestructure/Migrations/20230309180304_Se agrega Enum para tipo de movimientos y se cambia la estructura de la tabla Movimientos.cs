using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Management.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SeagregaEnumparatipodemovimientosysecambialaestructuradelatablaMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Movements");

            migrationBuilder.AddColumn<int>(
                name: "ActionId",
                table: "Movements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MovementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MovementTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Credito" },
                    { 2, "Debito" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movements_ActionId",
                table: "Movements",
                column: "ActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_MovementTypes_ActionId",
                table: "Movements",
                column: "ActionId",
                principalTable: "MovementTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_MovementTypes_ActionId",
                table: "Movements");

            migrationBuilder.DropTable(
                name: "MovementTypes");

            migrationBuilder.DropIndex(
                name: "IX_Movements_ActionId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "Movements");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Movements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
