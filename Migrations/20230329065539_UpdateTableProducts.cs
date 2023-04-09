using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intership.Migrations
{
    public partial class UpdateTableProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.Products",
                table: "dbo.Products");

            migrationBuilder.RenameTable(
                name: "dbo.Products",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "dbo.Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.Products",
                table: "dbo.Products",
                column: "Id");
        }
    }
}
