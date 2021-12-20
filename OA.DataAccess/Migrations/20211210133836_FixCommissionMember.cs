using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OA.DataAccess.Migrations
{
    public partial class FixCommissionMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommissionMembers_People_PersonId",
                table: "CommissionMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Decisions_Commissions_CommissionId",
                table: "Decisions");

            migrationBuilder.DropIndex(
                name: "IX_Decisions_CommissionId",
                table: "Decisions");

            migrationBuilder.DropIndex(
                name: "IX_CommissionMembers_PersonId",
                table: "CommissionMembers");

            migrationBuilder.DropColumn(
                name: "CommissionId",
                table: "Decisions");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "CommissionMembers");

            migrationBuilder.AlterColumn<string>(
                name: "DecisionNum",
                table: "Decisions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Decisions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "CommissionMembers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "CommissionMembers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdministrationBoardId",
                table: "CommissionMembers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DecisionId",
                table: "CommissionMembers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommissionMembers_AdministrationBoardId",
                table: "CommissionMembers",
                column: "AdministrationBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionMembers_DecisionId",
                table: "CommissionMembers",
                column: "DecisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommissionMembers_AdministrationBoards_AdministrationBoardId",
                table: "CommissionMembers",
                column: "AdministrationBoardId",
                principalTable: "AdministrationBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommissionMembers_Decisions_DecisionId",
                table: "CommissionMembers",
                column: "DecisionId",
                principalTable: "Decisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommissionMembers_AdministrationBoards_AdministrationBoardId",
                table: "CommissionMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommissionMembers_Decisions_DecisionId",
                table: "CommissionMembers");

            migrationBuilder.DropIndex(
                name: "IX_CommissionMembers_AdministrationBoardId",
                table: "CommissionMembers");

            migrationBuilder.DropIndex(
                name: "IX_CommissionMembers_DecisionId",
                table: "CommissionMembers");

            migrationBuilder.DropColumn(
                name: "AdministrationBoardId",
                table: "CommissionMembers");

            migrationBuilder.DropColumn(
                name: "DecisionId",
                table: "CommissionMembers");

            migrationBuilder.AlterColumn<int>(
                name: "DecisionNum",
                table: "Decisions",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Decisions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "CommissionId",
                table: "Decisions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "CommissionMembers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "CommissionMembers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "CommissionMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decisions_CommissionId",
                table: "Decisions",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionMembers_PersonId",
                table: "CommissionMembers",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommissionMembers_People_PersonId",
                table: "CommissionMembers",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Decisions_Commissions_CommissionId",
                table: "Decisions",
                column: "CommissionId",
                principalTable: "Commissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
