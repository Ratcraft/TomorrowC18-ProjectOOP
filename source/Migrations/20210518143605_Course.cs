using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TomorrowC18ProjectOOP.Migrations
{
    public partial class Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "teacherId",
                table: "Course",
                newName: "duration");

            migrationBuilder.AddColumn<string>(
                name: "group",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "teachername",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "group",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "teachername",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Course",
                newName: "teacherId");

            migrationBuilder.AddColumn<DateTime>(
                name: "end",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
