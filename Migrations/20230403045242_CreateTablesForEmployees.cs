using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intership.Migrations
{
    public partial class CreateTablesForEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrationDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employeesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberPhobne = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    RegistrationDataId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employeesses_RegistrationDatas_RegistrationDataId",
                        column: x => x.RegistrationDataId,
                        principalTable: "RegistrationDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employeesses_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employeesses_RegistrationDataId",
                table: "Employeesses",
                column: "RegistrationDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeesses_RoleId",
                table: "Employeesses",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employeesses");

            migrationBuilder.DropTable(
                name: "RegistrationDatas");
        }
    }
}
