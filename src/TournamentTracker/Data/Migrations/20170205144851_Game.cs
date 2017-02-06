using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TournamentTracker.Data.Migrations
{
    public partial class Game : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    RuleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rule = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.RuleID);
                });

            migrationBuilder.CreateTable(
                name: "BestPainted",
                columns: table => new
                {
                    BestPaintedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventID = table.Column<int>(nullable: false),
                    FirstPlace = table.Column<string>(nullable: false),
                    SecondPlace = table.Column<string>(nullable: true),
                    ThirdPlace = table.Column<string>(nullable: true),
                    VotingUser = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestPainted", x => x.BestPaintedID);
                    table.ForeignKey(
                        name: "FK_BestPainted_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BestPainted_AspNetUsers_FirstPlace",
                        column: x => x.FirstPlace,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BestPainted_AspNetUsers_SecondPlace",
                        column: x => x.SecondPlace,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BestPainted_AspNetUsers_ThirdPlace",
                        column: x => x.ThirdPlace,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BestPainted_AspNetUsers_VotingUser",
                        column: x => x.VotingUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EventArmyList",
                columns: table => new
                {
                    EventArmyListID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventID = table.Column<int>(nullable: false),
                    List = table.Column<string>(nullable: true),
                    ListURL = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventArmyList", x => x.EventArmyListID);
                    table.ForeignKey(
                        name: "FK_EventArmyList_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventArmyList_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPlayers",
                columns: table => new
                {
                    EventPlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventID = table.Column<int>(nullable: false),
                    Player = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlayers", x => x.EventPlayerID);
                    table.ForeignKey(
                        name: "FK_EventPlayers_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPlayers_AspNetUsers_Player",
                        column: x => x.Player,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesRules",
                columns: table => new
                {
                    GameRulesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExtraRules = table.Column<int>(nullable: false),
                    PrimaryMission1 = table.Column<int>(nullable: false),
                    PrimaryMission2 = table.Column<int>(nullable: false),
                    PrimaryMissionDrawScore = table.Column<int>(nullable: false),
                    PrimaryMissionWinScore = table.Column<int>(nullable: false),
                    SecondaryMissio3 = table.Column<int>(nullable: true),
                    SecondaryMission1 = table.Column<int>(nullable: false),
                    SecondaryMission2 = table.Column<int>(nullable: false),
                    SecondaryMission3 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesRules", x => x.GameRulesID);
                    table.ForeignKey(
                        name: "FK_GamesRules_Rules_PrimaryMission1",
                        column: x => x.PrimaryMission1,
                        principalTable: "Rules",
                        principalColumn: "RuleID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GamesRules_Rules_PrimaryMission2",
                        column: x => x.PrimaryMission2,
                        principalTable: "Rules",
                        principalColumn: "RuleID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GamesRules_Rules_SecondaryMissio3",
                        column: x => x.SecondaryMissio3,
                        principalTable: "Rules",
                        principalColumn: "RuleID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GamesRules_Rules_SecondaryMission1",
                        column: x => x.SecondaryMission1,
                        principalTable: "Rules",
                        principalColumn: "RuleID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GamesRules_Rules_SecondaryMission2",
                        column: x => x.SecondaryMission2,
                        principalTable: "Rules",
                        principalColumn: "RuleID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GameScores",
                columns: table => new
                {
                    GameScoreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameID = table.Column<int>(nullable: false),
                    Player = table.Column<string>(nullable: false),
                    Primary2Score = table.Column<int>(nullable: false),
                    PrimaryScore = table.Column<int>(nullable: false),
                    SecondaryScore = table.Column<int>(nullable: false),
                    SportsmanScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameScores", x => x.GameScoreID);
                    table.ForeignKey(
                        name: "FK_GameScores_AspNetUsers_Player",
                        column: x => x.Player,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameLength = table.Column<TimeSpan>(nullable: false),
                    GameRulesID = table.Column<int>(nullable: false),
                    GameScoreID = table.Column<int>(nullable: false),
                    Player1 = table.Column<string>(nullable: false),
                    Player2 = table.Column<string>(nullable: false),
                    Round = table.Column<int>(nullable: false),
                    Table = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Games_GamesRules_GameRulesID",
                        column: x => x.GameRulesID,
                        principalTable: "GamesRules",
                        principalColumn: "GameRulesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_GameScores_GameScoreID",
                        column: x => x.GameScoreID,
                        principalTable: "GameScores",
                        principalColumn: "GameScoreID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Games_AspNetUsers_Player1",
                        column: x => x.Player1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Games_AspNetUsers_Player2",
                        column: x => x.Player2,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameRulesID",
                table: "Games",
                column: "GameRulesID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameScoreID",
                table: "Games",
                column: "GameScoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Player1",
                table: "Games",
                column: "Player1");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Player2",
                table: "Games",
                column: "Player2");

            migrationBuilder.CreateIndex(
                name: "IX_GameScores_GameID",
                table: "GameScores",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_GameScores_Player",
                table: "GameScores",
                column: "Player");

            migrationBuilder.CreateIndex(
                name: "IX_GamesRules_PrimaryMission1",
                table: "GamesRules",
                column: "PrimaryMission1");

            migrationBuilder.CreateIndex(
                name: "IX_GamesRules_PrimaryMission2",
                table: "GamesRules",
                column: "PrimaryMission2");

            migrationBuilder.CreateIndex(
                name: "IX_GamesRules_SecondaryMissio3",
                table: "GamesRules",
                column: "SecondaryMissio3");

            migrationBuilder.CreateIndex(
                name: "IX_GamesRules_SecondaryMission1",
                table: "GamesRules",
                column: "SecondaryMission1");

            migrationBuilder.CreateIndex(
                name: "IX_GamesRules_SecondaryMission2",
                table: "GamesRules",
                column: "SecondaryMission2");

            migrationBuilder.CreateIndex(
                name: "IX_BestPainted_EventID",
                table: "BestPainted",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_BestPainted_FirstPlace",
                table: "BestPainted",
                column: "FirstPlace");

            migrationBuilder.CreateIndex(
                name: "IX_BestPainted_SecondPlace",
                table: "BestPainted",
                column: "SecondPlace");

            migrationBuilder.CreateIndex(
                name: "IX_BestPainted_ThirdPlace",
                table: "BestPainted",
                column: "ThirdPlace");

            migrationBuilder.CreateIndex(
                name: "IX_BestPainted_VotingUser",
                table: "BestPainted",
                column: "VotingUser");

            migrationBuilder.CreateIndex(
                name: "IX_EventArmyList_EventID",
                table: "EventArmyList",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventArmyList_UserID",
                table: "EventArmyList",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlayers_EventID",
                table: "EventPlayers",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlayers_Player",
                table: "EventPlayers",
                column: "Player");

            migrationBuilder.AddForeignKey(
                name: "FK_GameScores_Games_GameID",
                table: "GameScores",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GamesRules_GameRulesID",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameScores_GameScoreID",
                table: "Games");

            migrationBuilder.DropTable(
                name: "BestPainted");

            migrationBuilder.DropTable(
                name: "EventArmyList");

            migrationBuilder.DropTable(
                name: "EventPlayers");

            migrationBuilder.DropTable(
                name: "GamesRules");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "GameScores");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
