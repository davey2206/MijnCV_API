using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MijnCV_API.Migrations
{
    public partial class pageupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Pages");

            migrationBuilder.AddColumn<string>(
                name: "cv",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cv",
                table: "Pages");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
