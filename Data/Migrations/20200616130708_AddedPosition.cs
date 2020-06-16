using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddedPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PlayerPositions");

            migrationBuilder.AddColumn<int>(
                name: "position",
                table: "PlayerPositions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "position",
                table: "PlayerPositions");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PlayerPositions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
