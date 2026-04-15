using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreetStatusAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Street = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    created_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_by_id = table.Column<string>(type: "TEXT", nullable: true),
                    updated_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "streets",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    street_name = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    last_repair_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    location_id = table.Column<string>(type: "TEXT", nullable: false),
                    created_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_by_id = table.Column<string>(type: "TEXT", nullable: true),
                    updated_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_streets", x => x.id);
                    table.ForeignKey(
                        name: "FK_streets_locations_location_id",
                        column: x => x.location_id,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_streets_location_id",
                table: "streets",
                column: "location_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "streets");

            migrationBuilder.DropTable(
                name: "locations");
        }
    }
}
