using Microsoft.EntityFrameworkCore.Migrations;

namespace PawełGryglewiczLab6PracDom.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDCardSerialNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsOddWeek",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "IdCardSerialNumber",
                table: "Lecturers");

            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "Lecturers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Pesel",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IDCardSerialNumber",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOddWeek",
                table: "Lessons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Pesel",
                table: "Lecturers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IdCardSerialNumber",
                table: "Lecturers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
