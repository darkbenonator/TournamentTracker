using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentTracker.Data.Migrations
{
    public partial class UpdateLocationAndAddRegex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "Location",
                maxLength: 10,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Location",
                maxLength: 35,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "Location",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Location",
                maxLength: 20,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Location",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Location",
                maxLength: 30,
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Location",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookURL",
                table: "Location",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Location",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterURL",
                table: "Location",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteURL",
                table: "Location",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ListURL",
                table: "EventArmyList",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "List",
                table: "EventArmyList",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfTables",
                table: "Event",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "FoodDescription",
                table: "Event",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventRestrictions",
                table: "Event",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventPackURL",
                table: "Event",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Event",
                maxLength: 20,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Event",
                maxLength: 1500,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "FacebookURL",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "TwitterURL",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "WebsiteURL",
                table: "Location");

            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "Location",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Location",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "Location",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Location",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Location",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Location",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ListURL",
                table: "EventArmyList",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "List",
                table: "EventArmyList",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumberOfTables",
                table: "Event",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "FoodDescription",
                table: "Event",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventRestrictions",
                table: "Event",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventPackURL",
                table: "Event",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Event",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Event",
                nullable: false);
        }
    }
}
