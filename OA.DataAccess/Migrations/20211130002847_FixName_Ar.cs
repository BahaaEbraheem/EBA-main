using Microsoft.EntityFrameworkCore.Migrations;

namespace OA.DataAccess.Migrations
{
    public partial class FixName_Ar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "TrainingExperiences");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "TrainingCourseTypes");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "TrainingCourses");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "PTypes");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Title_Ar",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "Title_En",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "ImportantAchievements");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "GameTypes");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Fcilities");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Commissions");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "ChampionshipTypes");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "ChampionshipsRanking");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Championships");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "ChampionshipRoles");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "ArrowTypes");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "AlbumContent");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "AgeCategories");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Adjectives");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TrainingExperiences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TrainingCourseTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TrainingCourses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stadiums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Nationalities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_En",
                table: "Nationalities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ImportantAchievements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GameTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Fcilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Commissions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Clubs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ChampionshipTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ChampionshipsRanking",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Championships",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ChampionshipRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ArrowTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Albums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AlbumContent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AgeCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Adjectives",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TrainingExperiences");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TrainingCourseTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TrainingCourses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "Name_En",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ImportantAchievements");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GameTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Fcilities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Commissions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ChampionshipTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ChampionshipsRanking");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Championships");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ChampionshipRoles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ArrowTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AlbumContent");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AgeCategories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Adjectives");

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "TrainingExperiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "TrainingCourseTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "TrainingCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "PTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_Ar",
                table: "Nationalities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_En",
                table: "Nationalities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "ImportantAchievements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "GameTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Fcilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Commissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "ChampionshipTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "ChampionshipsRanking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Championships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "ChampionshipRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "ArrowTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "AlbumContent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "AgeCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Adjectives",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
