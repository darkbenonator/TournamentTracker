using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentTracker.Data.Migrations
{
    public partial class GameAndEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Location",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Event",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Event",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "EventRestrictions",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoodDescription",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberOfTables",
                table: "Event",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventRestrictions",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "FoodDescription",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "NumberOfTables",
                table: "Event");

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Location",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Event",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Event",
                nullable: true);
        }
    }
}
