using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MID_BCS240034.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventCategories_BCS240034",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories_BCS240034", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events_BCS240034",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events_BCS240034", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_BCS240034_EventCategories_BCS240034_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories_BCS240034",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventImages_BCS240034",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsThumbnail = table.Column<bool>(type: "bit", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventImages_BCS240034", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventImages_BCS240034_Events_BCS240034_EventId",
                        column: x => x.EventId,
                        principalTable: "Events_BCS240034",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventImages_BCS240034_EventId",
                table: "EventImages_BCS240034",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_BCS240034_EventCategoryId",
                table: "Events_BCS240034",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_BCS240034_Name_StartDate",
                table: "Events_BCS240034",
                columns: new[] { "Name", "StartDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventImages_BCS240034");

            migrationBuilder.DropTable(
                name: "Events_BCS240034");

            migrationBuilder.DropTable(
                name: "EventCategories_BCS240034");
        }
    }
}
