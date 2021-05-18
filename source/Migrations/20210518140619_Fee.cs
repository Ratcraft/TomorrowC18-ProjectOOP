using Microsoft.EntityFrameworkCore.Migrations;

namespace TomorrowC18ProjectOOP.Migrations
{
    public partial class Fee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "facultyId",
                table: "Fee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "ispayed",
                table: "Fee",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ispayed",
                table: "Fee");

            migrationBuilder.AlterColumn<int>(
                name: "facultyId",
                table: "Fee",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
