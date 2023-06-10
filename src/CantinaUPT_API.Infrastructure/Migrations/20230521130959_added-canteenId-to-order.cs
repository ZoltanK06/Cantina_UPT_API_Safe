using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CantinaUPT_API.Infrastructure.Migrations
{
    public partial class addedcanteenIdtoorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CanteenId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanteenId",
                table: "Orders");
        }
    }
}
