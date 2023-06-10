using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CantinaUPT_API.Infrastructure.Migrations
{
    public partial class userroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CanteenId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CanteenId",
                table: "Users",
                column: "CanteenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Canteens_CanteenId",
                table: "Users",
                column: "CanteenId",
                principalTable: "Canteens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Canteens_CanteenId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CanteenId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CanteenId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
