using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TournamentTracker.Data.Migrations
{
    public partial class AddedGameConnectionsAndFixSecondaryMission3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesRules_Rules_SecondaryMissio3",
                table: "GamesRules");

            migrationBuilder.DropIndex(
                name: "IX_GamesRules_SecondaryMissio3",
                table: "GamesRules");

            migrationBuilder.DropColumn(
                name: "SecondaryMissio3",
                table: "GamesRules");

            migrationBuilder.AlterColumn<string>(
                name: "WebsiteURL",
                table: "Location",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TwitterURL",
                table: "Location",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacebookURL",
                table: "Location",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ListURL",
                table: "EventArmyList",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventPackURL",
                table: "Event",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Games",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedTime",
                table: "Games",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GameConnectedPlayers",
                columns: table => new
                {
                    ConnectedPlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConnectedTime = table.Column<DateTime>(nullable: false),
                    ConnectionID = table.Column<string>(maxLength: 200, nullable: true),
                    DisconnectedTime = table.Column<DateTime>(nullable: false),
                    EventID = table.Column<int>(nullable: false),
                    Player = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConnectedPlayers", x => x.ConnectedPlayerID);
                    table.ForeignKey(
                        name: "FK_GameConnectedPlayers_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameConnectedPlayers_AspNetUsers_Player",
                        column: x => x.Player,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamesRules_SecondaryMission3",
                table: "GamesRules",
                column: "SecondaryMission3");

            migrationBuilder.CreateIndex(
                name: "IX_GameConnectedPlayers_EventID",
                table: "GameConnectedPlayers",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_GameConnectedPlayers_Player",
                table: "GameConnectedPlayers",
                column: "Player");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesRules_Rules_SecondaryMission3",
                table: "GamesRules",
                column: "SecondaryMission3",
                principalTable: "Rules",
                principalColumn: "RuleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesRules_Rules_SecondaryMission3",
                table: "GamesRules");

            migrationBuilder.DropTable(
                name: "GameConnectedPlayers");

            migrationBuilder.DropIndex(
                name: "IX_GamesRules_SecondaryMission3",
                table: "GamesRules");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "StartedTime",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "WebsiteURL",
                table: "Location",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TwitterURL",
                table: "Location",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacebookURL",
                table: "Location",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ListURL",
                table: "EventArmyList",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventPackURL",
                table: "Event",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryMissio3",
                table: "GamesRules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamesRules_SecondaryMissio3",
                table: "GamesRules",
                column: "SecondaryMissio3");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesRules_Rules_SecondaryMissio3",
                table: "GamesRules",
                column: "SecondaryMissio3",
                principalTable: "Rules",
                principalColumn: "RuleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
