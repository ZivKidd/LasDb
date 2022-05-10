using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LasDb.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "X2D",
                table: "LasPointDbs");

            migrationBuilder.DropColumn(
                name: "Y2D",
                table: "LasPointDbs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "X2D",
                table: "LasPointDbs",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Y2D",
                table: "LasPointDbs",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
