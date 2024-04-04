using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations.newAddedDB
{
    /// <inheritdoc />
    public partial class updateNewAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lib",
                table: "newGlassType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "perUnit",
                table: "newGlassType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "lib",
                table: "newFrameType",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lib",
                table: "newGlassType");

            migrationBuilder.DropColumn(
                name: "perUnit",
                table: "newGlassType");

            migrationBuilder.DropColumn(
                name: "lib",
                table: "newFrameType");
        }
    }
}
