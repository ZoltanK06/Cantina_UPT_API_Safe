using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CantinaUPT_API.Infrastructure.Migrations
{
    public partial class nullablecanteenId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Canteens_CanteenId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CanteenId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Canteens_CanteenId",
                table: "Users",
                column: "CanteenId",
                principalTable: "Canteens",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Canteens_CanteenId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CanteenId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Canteens_CanteenId",
                table: "Users",
                column: "CanteenId",
                principalTable: "Canteens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
