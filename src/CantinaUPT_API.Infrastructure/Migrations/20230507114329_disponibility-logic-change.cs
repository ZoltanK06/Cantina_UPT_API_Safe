using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CantinaUPT_API.Infrastructure.Migrations
{
    public partial class disponibilitylogicchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disponibilities");

            migrationBuilder.AddColumn<bool>(
                name: "Disponibility",
                table: "Meals",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponibility",
                table: "Meals");

            migrationBuilder.CreateTable(
                name: "Disponibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanteenId = table.Column<int>(type: "int", nullable: false),
                    Disposable = table.Column<bool>(type: "bit", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilities", x => x.Id);
                });
        }
    }
}
