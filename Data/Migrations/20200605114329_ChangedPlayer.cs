using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ChangedPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preference_one",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Preference_three",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Preference_two",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "id",
                keyValue: 1,
                column: "Age",
                value: 17);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "Preference_one",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Preference_three",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Preference_two",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "Preference_one", "Preference_three", "Preference_two", "Priority" },
                values: new object[] { 4, 6, 2, 6 });
        }
    }
}
