using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations.newAddedDB
{
    /// <inheritdoc />
    public partial class fixBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerUnit",
                table: "newFrameType");

            migrationBuilder.DropColumn(
                name: "lib",
                table: "newFrameType");

            migrationBuilder.AlterColumn<double>(
                name: "perUnit",
                table: "newGlassType",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "lib",
                table: "newGlassType",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Priority",
                table: "newGlassType",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "perUnit",
                table: "newGlassType",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "lib",
                table: "newGlassType",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "newGlassType",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "PerUnit",
                table: "newFrameType",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "lib",
                table: "newFrameType",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
