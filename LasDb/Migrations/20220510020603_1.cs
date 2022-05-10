using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LasDb.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LasPointDbs",
                columns: table => new
                {
                    Index = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    X = table.Column<double>(type: "REAL", nullable: false),
                    Y = table.Column<double>(type: "REAL", nullable: false),
                    Z = table.Column<double>(type: "REAL", nullable: false),
                    Intensity = table.Column<ushort>(type: "INTEGER", nullable: false),
                    X2D = table.Column<double>(type: "REAL", nullable: false),
                    Y2D = table.Column<double>(type: "REAL", nullable: false),
                    ScanLineIndex = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LasPointDbs", x => x.Index);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LasPointDbs_ScanLineIndex",
                table: "LasPointDbs",
                column: "ScanLineIndex");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LasPointDbs");
        }
    }
}
