using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ewaste_Collection.Data.Migrations
{
    public partial class Initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ewaste",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    pickupdate = table.Column<DateTime>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    weight = table.Column<double>(nullable: false),
                    ecopoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ewaste", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ewaste");
        }
    }
}
