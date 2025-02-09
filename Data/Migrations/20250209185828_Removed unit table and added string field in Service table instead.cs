using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedunittableandaddedstringfieldinServicetableinstead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Units_UnitId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Services_UnitId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Services",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_UnitId",
                table: "Services",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_Unit",
                table: "Units",
                column: "Unit",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Units_UnitId",
                table: "Services",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
