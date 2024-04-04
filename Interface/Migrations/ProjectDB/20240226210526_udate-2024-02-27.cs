using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations.ProjectDB
{
    /// <inheritdoc />
    public partial class udate20240227 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrintName",
                table: "Factors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Signed",
                table: "Factors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrintName",
                table: "Factors");

            migrationBuilder.DropColumn(
                name: "Signed",
                table: "Factors");
        }
    }
}
