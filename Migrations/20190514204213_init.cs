using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wizme.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Img = table.Column<string>(nullable: true),
                    Descreption = table.Column<string>(nullable: true),
                    Chain = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    VenueId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spaces_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Brand", "Chain", "Descreption", "Img" },
                values: new object[] { new Guid("02d54ac3-93e0-4766-918a-9a83786ae1fd"), null, null, "my first venue", null });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Brand", "Chain", "Descreption", "Img" },
                values: new object[] { new Guid("f790c5a4-3e8d-4834-afbe-473ac318fdec"), null, null, "my second venue", null });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Brand", "Chain", "Descreption", "Img" },
                values: new object[] { new Guid("086b08e7-623c-4832-b557-230b9b5b82cb"), null, null, "my third venue", null });

            migrationBuilder.InsertData(
                table: "Spaces",
                columns: new[] { "Id", "Name", "Price", "Shape", "VenueId" },
                values: new object[,]
                {
                    { new Guid("59bc648c-4df3-4eb5-a71f-601e5a139ca4"), null, 1.01, "U-Theatre", new Guid("02d54ac3-93e0-4766-918a-9a83786ae1fd") },
                    { new Guid("8f1b65ea-5c1e-4c01-8208-bdddc6f2af24"), null, 1.01, "Shape2", new Guid("02d54ac3-93e0-4766-918a-9a83786ae1fd") },
                    { new Guid("4a13b39b-bb4c-4979-9509-899c206db6bb"), null, 1.01, "Shape3", new Guid("02d54ac3-93e0-4766-918a-9a83786ae1fd") },
                    { new Guid("484b86b0-295e-4535-8fcd-72ca39de4eed"), null, 2.0, "Square", new Guid("f790c5a4-3e8d-4834-afbe-473ac318fdec") },
                    { new Guid("32b2639d-23aa-4b42-9957-ff0e1a6f34d5"), null, 2.0, "3atees", new Guid("f790c5a4-3e8d-4834-afbe-473ac318fdec") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_VenueId",
                table: "Spaces",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spaces");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
