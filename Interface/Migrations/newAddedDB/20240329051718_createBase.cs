using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations.newAddedDB
{
    /// <inheritdoc />
    public partial class createBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "FabricationCategories",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricationCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GlassExtraPrices",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassExtraPrices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GlassOptions",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassOptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GlassStrengths",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassStrengths", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GlassThicknes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassThicknes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GlassTypes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Fabrications",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerUnit = table.Column<double>(type: "float", nullable: false),
                    FabricationCategoryID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fabrications_FabricationCategories_FabricationCategoryID",
                        column: x => x.FabricationCategoryID,
                        principalSchema: "dbo",
                        principalTable: "FabricationCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GlassPrices",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlassTypeID = table.Column<int>(type: "int", nullable: false),
                    GlassOptionID = table.Column<int>(type: "int", nullable: false),
                    GlassThicknesID = table.Column<int>(type: "int", nullable: false),
                    GlassStrengthID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassPrices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GlassPrices_GlassOptions_GlassOptionID",
                        column: x => x.GlassOptionID,
                        principalSchema: "dbo",
                        principalTable: "GlassOptions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GlassType_Option",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlassOptionID = table.Column<int>(type: "int", nullable: false),
                    GlassTypeID = table.Column<int>(type: "int", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassType_Option", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GlassType_Option_GlassOptions_GlassOptionID",
                        column: x => x.GlassOptionID,
                        principalSchema: "dbo",
                        principalTable: "GlassOptions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlassType_Option_GlassTypes_GlassTypeID",
                        column: x => x.GlassTypeID,
                        principalSchema: "dbo",
                        principalTable: "GlassTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GlassType_Strength",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlassStrengthID = table.Column<int>(type: "int", nullable: false),
                    GlassTypeID = table.Column<int>(type: "int", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassType_Strength", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GlassType_Strength_GlassStrengths_GlassStrengthID",
                        column: x => x.GlassStrengthID,
                        principalSchema: "dbo",
                        principalTable: "GlassStrengths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlassType_Strength_GlassTypes_GlassTypeID",
                        column: x => x.GlassTypeID,
                        principalSchema: "dbo",
                        principalTable: "GlassTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GlassType_Thicknes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlassThicknesID = table.Column<int>(type: "int", nullable: false),
                    GlassTypeID = table.Column<int>(type: "int", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassType_Thicknes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GlassType_Thicknes_GlassThicknes_GlassThicknesID",
                        column: x => x.GlassThicknesID,
                        principalSchema: "dbo",
                        principalTable: "GlassThicknes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlassType_Thicknes_GlassTypes_GlassTypeID",
                        column: x => x.GlassTypeID,
                        principalSchema: "dbo",
                        principalTable: "GlassTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FabricationPrices",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlassThicknesID = table.Column<int>(type: "int", nullable: false),
                    FabricationID = table.Column<int>(type: "int", nullable: false),
                    GlassStrengthID = table.Column<int>(type: "int", nullable: false),
                    Sqf25 = table.Column<byte>(type: "tinyint", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricationPrices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FabricationPrices_Fabrications_FabricationID",
                        column: x => x.FabricationID,
                        principalSchema: "dbo",
                        principalTable: "Fabrications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FabricationPrices_GlassThicknes_GlassThicknesID",
                        column: x => x.GlassThicknesID,
                        principalSchema: "dbo",
                        principalTable: "GlassThicknes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Glass_Fabrications",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlassTypeID = table.Column<int>(type: "int", nullable: false),
                    FabricationID = table.Column<int>(type: "int", nullable: false),
                    modifiedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glass_Fabrications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Glass_Fabrications_Fabrications_FabricationID",
                        column: x => x.FabricationID,
                        principalSchema: "dbo",
                        principalTable: "Fabrications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Glass_Fabrications_GlassTypes_GlassTypeID",
                        column: x => x.GlassTypeID,
                        principalSchema: "dbo",
                        principalTable: "GlassTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FabricationPrices_FabricationID",
                schema: "dbo",
                table: "FabricationPrices",
                column: "FabricationID");

            migrationBuilder.CreateIndex(
                name: "IX_FabricationPrices_GlassThicknesID",
                schema: "dbo",
                table: "FabricationPrices",
                column: "GlassThicknesID");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrications_FabricationCategoryID",
                schema: "dbo",
                table: "Fabrications",
                column: "FabricationCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Glass_Fabrications_FabricationID",
                schema: "dbo",
                table: "Glass_Fabrications",
                column: "FabricationID");

            migrationBuilder.CreateIndex(
                name: "IX_Glass_Fabrications_GlassTypeID",
                schema: "dbo",
                table: "Glass_Fabrications",
                column: "GlassTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GlassPrices_GlassOptionID",
                schema: "dbo",
                table: "GlassPrices",
                column: "GlassOptionID");

            migrationBuilder.CreateIndex(
                name: "IX_GlassType_Option_GlassOptionID",
                schema: "dbo",
                table: "GlassType_Option",
                column: "GlassOptionID");

            migrationBuilder.CreateIndex(
                name: "IX_GlassType_Option_GlassTypeID",
                schema: "dbo",
                table: "GlassType_Option",
                column: "GlassTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GlassType_Strength_GlassStrengthID",
                schema: "dbo",
                table: "GlassType_Strength",
                column: "GlassStrengthID");

            migrationBuilder.CreateIndex(
                name: "IX_GlassType_Strength_GlassTypeID",
                schema: "dbo",
                table: "GlassType_Strength",
                column: "GlassTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GlassType_Thicknes_GlassThicknesID",
                schema: "dbo",
                table: "GlassType_Thicknes",
                column: "GlassThicknesID");

            migrationBuilder.CreateIndex(
                name: "IX_GlassType_Thicknes_GlassTypeID",
                schema: "dbo",
                table: "GlassType_Thicknes",
                column: "GlassTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FabricationPrices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Glass_Fabrications",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GlassExtraPrices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GlassPrices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GlassType_Option",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GlassType_Strength",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GlassType_Thicknes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Fabrications",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GlassOptions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GlassStrengths",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GlassThicknes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GlassTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FabricationCategories",
                schema: "dbo");
        }
    }
}
