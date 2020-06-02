using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddingUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Teams",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Teams",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teams",
                newName: "id");
        }
    }
}
