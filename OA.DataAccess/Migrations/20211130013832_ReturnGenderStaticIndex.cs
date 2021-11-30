using Microsoft.EntityFrameworkCore.Migrations;

namespace OA.DataAccess.Migrations
{
    public partial class ReturnGenderStaticIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "People",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                table: "People",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
