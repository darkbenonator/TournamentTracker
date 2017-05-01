using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TournamentTracker.Data.Migrations
{
    public partial class LocationAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Location",
                maxLength: 35,
                nullable: false);

            migrationBuilder.CreateTable(
                name: "LocationAdmin",
                columns: table => new
                {
                    LocationAdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationAdmin", x => x.LocationAdminID);
                    table.ForeignKey(
                        name: "FK_LocationAdmin_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationAdmin_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationAdmin_LocationID",
                table: "LocationAdmin",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_LocationAdmin_UserID",
                table: "LocationAdmin",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationAdmin");

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Location",
                maxLength: 20,
                nullable: false);
        }
    }
}
