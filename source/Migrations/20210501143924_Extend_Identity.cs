using Microsoft.EntityFrameworkCore.Migrations;

namespace TomorrowC18ProjectOOP.Migrations
{
    public partial class Extend_Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sex",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "birthDate",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "levelAccess",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "progress",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "group",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "subjectList",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "subject",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "groupList",
                table: "AspNetUsers",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sex",
                table: "AspNetUsers");
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "AspNetUsers");
            migrationBuilder.DropColumn(
                name: "lastName",
                table: "AspNetUsers");
            migrationBuilder.DropColumn(
                name: "birthDate",
                table: "AspNetUsers");
            migrationBuilder.DropColumn(
                name: "levelAccess",
                table: "AspNetUsers");
            migrationBuilder.DropColumn(
                name: "progress",
                table: "AspNetUsers");
            migrationBuilder.DropColumn(
                name: "group",
                table: "AspNetUsers");
            migrationBuilder.DropColumn(
                name: "subjectList",
                table: "AspNetUsers");
            migrationBuilder.DropColumn(
                name: "subject",
                table: "AspNetUsers");
            migrationBuilder.DropColumn(
                name: "groupList",
                table: "AspNetUsers");
        }
    }
}
