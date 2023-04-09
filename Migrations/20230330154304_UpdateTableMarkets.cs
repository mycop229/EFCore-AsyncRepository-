using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intership.Migrations
{
    public partial class UpdateTableMarkets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MarketId",
                table: "Markets",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Markets",
                newName: "MarketId");
        }
    }
}
