using Microsoft.EntityFrameworkCore.Migrations;

namespace OA.DataAccess.Migrations
{
    public partial class FixRanking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Championships_ChampionshipRanking_ChampionshipRankingId",
                table: "Championships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChampionshipRanking",
                table: "ChampionshipRanking");

            migrationBuilder.RenameTable(
                name: "ChampionshipRanking",
                newName: "ChampionshipsRanking");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChampionshipsRanking",
                table: "ChampionshipsRanking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Championships_ChampionshipsRanking_ChampionshipRankingId",
                table: "Championships",
                column: "ChampionshipRankingId",
                principalTable: "ChampionshipsRanking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Championships_ChampionshipsRanking_ChampionshipRankingId",
                table: "Championships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChampionshipsRanking",
                table: "ChampionshipsRanking");

            migrationBuilder.RenameTable(
                name: "ChampionshipsRanking",
                newName: "ChampionshipRanking");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChampionshipRanking",
                table: "ChampionshipRanking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Championships_ChampionshipRanking_ChampionshipRankingId",
                table: "Championships",
                column: "ChampionshipRankingId",
                principalTable: "ChampionshipRanking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
