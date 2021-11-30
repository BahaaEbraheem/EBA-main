using Microsoft.EntityFrameworkCore.Migrations;

namespace OA.DataAccess.Migrations
{
    public partial class FixGenderStaticIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                table: "People",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte));
        }
    }
}
