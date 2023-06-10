using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CantinaUPT_API.Infrastructure.Migrations
{
    public partial class updatedcardmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CvcHash",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CvcSalt",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "NumberHash",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "NumberSalt",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "EncryptedCvc",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EncryptedNumber",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EncryptedCvc",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "EncryptedNumber",
                table: "Cards");

            migrationBuilder.AddColumn<byte[]>(
                name: "CvcHash",
                table: "Cards",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "CvcSalt",
                table: "Cards",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "NumberHash",
                table: "Cards",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "NumberSalt",
                table: "Cards",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
