using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentTracker.Data.Migrations
{
    public partial class updateGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameScores_GameScoreID",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_GameScores_Games_GameID",
                table: "GameScores");

            migrationBuilder.DropIndex(
                name: "IX_GameScores_GameID",
                table: "GameScores");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "GameScores");

            migrationBuilder.RenameColumn(
                name: "Round",
                table: "Games",
                newName: "Player2Score");

            migrationBuilder.RenameColumn(
                name: "GameScoreID",
                table: "Games",
                newName: "Player1Score");

            migrationBuilder.RenameIndex(
                name: "IX_Games_GameScoreID",
                table: "Games",
                newName: "IX_Games_Player1Score");

            migrationBuilder.AlterColumn<string>(
                name: "Rule",
                table: "Rules",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuleName",
                table: "Rules",
                maxLength: 35,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ExtraRules",
                table: "GamesRules",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "GamesRules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "GameLength",
                table: "GamesRules",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Round",
                table: "GamesRules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryMissionDrawScore",
                table: "GamesRules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryMissionWinScore",
                table: "GamesRules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "CurrentGameTime",
                table: "Games",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_GamesRules_EventID",
                table: "GamesRules",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Player2Score",
                table: "Games",
                column: "Player2Score");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameScores_Player1Score",
                table: "Games",
                column: "Player1Score",
                principalTable: "GameScores",
                principalColumn: "GameScoreID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameScores_Player2Score",
                table: "Games",
                column: "Player2Score",
                principalTable: "GameScores",
                principalColumn: "GameScoreID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GamesRules_Event_EventID",
                table: "GamesRules",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameScores_Player1Score",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameScores_Player2Score",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesRules_Event_EventID",
                table: "GamesRules");

            migrationBuilder.DropIndex(
                name: "IX_GamesRules_EventID",
                table: "GamesRules");

            migrationBuilder.DropIndex(
                name: "IX_Games_Player2Score",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "RuleName",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "GamesRules");

            migrationBuilder.DropColumn(
                name: "GameLength",
                table: "GamesRules");

            migrationBuilder.DropColumn(
                name: "Round",
                table: "GamesRules");

            migrationBuilder.DropColumn(
                name: "SecondaryMissionDrawScore",
                table: "GamesRules");

            migrationBuilder.DropColumn(
                name: "SecondaryMissionWinScore",
                table: "GamesRules");

            migrationBuilder.DropColumn(
                name: "CurrentGameTime",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Player2Score",
                table: "Games",
                newName: "Round");

            migrationBuilder.RenameColumn(
                name: "Player1Score",
                table: "Games",
                newName: "GameScoreID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Player1Score",
                table: "Games",
                newName: "IX_Games_GameScoreID");

            migrationBuilder.AlterColumn<string>(
                name: "Rule",
                table: "Rules",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "ExtraRules",
                table: "GamesRules",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "GameScores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameScores_GameID",
                table: "GameScores",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameScores_GameScoreID",
                table: "Games",
                column: "GameScoreID",
                principalTable: "GameScores",
                principalColumn: "GameScoreID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GameScores_Games_GameID",
                table: "GameScores",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
