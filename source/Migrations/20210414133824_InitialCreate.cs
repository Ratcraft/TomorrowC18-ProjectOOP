using Microsoft.EntityFrameworkCore.Migrations;

namespace TomorrowC18ProjectOOP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicCalendar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicCalendar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    progress = table.Column<int>(type: "int", nullable: true),
                    subjectList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicCalendar");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
