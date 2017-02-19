using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TournamentTracker.Data;

namespace TournamentTracker.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170216171836_UpdateLocationAndAddRegex")]
    partial class UpdateLocationAndAddRegex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TournamentTracker.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TournamentTracker.Models.GameModels.Games", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("GameLength");

                    b.Property<int>("GameRulesID");

                    b.Property<int>("GameScoreID");

                    b.Property<string>("Player1")
                        .IsRequired();

                    b.Property<string>("Player2")
                        .IsRequired();

                    b.Property<int>("Round");

                    b.Property<int>("Table");

                    b.HasKey("GameID");

                    b.HasIndex("GameRulesID");

                    b.HasIndex("GameScoreID");

                    b.HasIndex("Player1");

                    b.HasIndex("Player2");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TournamentTracker.Models.GameModels.GameScores", b =>
                {
                    b.Property<int>("GameScoreID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameID");

                    b.Property<string>("Player")
                        .IsRequired();

                    b.Property<int>("Primary2Score");

                    b.Property<int>("PrimaryScore");

                    b.Property<int>("SecondaryScore");

                    b.Property<int>("SportsmanScore");

                    b.HasKey("GameScoreID");

                    b.HasIndex("GameID");

                    b.HasIndex("Player");

                    b.ToTable("GameScores");
                });

            modelBuilder.Entity("TournamentTracker.Models.GameModels.GamesRules", b =>
                {
                    b.Property<int>("GameRulesID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExtraRules");

                    b.Property<int>("PrimaryMission1");

                    b.Property<int>("PrimaryMission2");

                    b.Property<int>("PrimaryMissionDrawScore");

                    b.Property<int>("PrimaryMissionWinScore");

                    b.Property<int?>("SecondaryMissio3");

                    b.Property<int>("SecondaryMission1");

                    b.Property<int>("SecondaryMission2");

                    b.Property<int>("SecondaryMission3");

                    b.HasKey("GameRulesID");

                    b.HasIndex("PrimaryMission1");

                    b.HasIndex("PrimaryMission2");

                    b.HasIndex("SecondaryMissio3");

                    b.HasIndex("SecondaryMission1");

                    b.HasIndex("SecondaryMission2");

                    b.ToTable("GamesRules");
                });

            modelBuilder.Entity("TournamentTracker.Models.GameModels.Rules", b =>
                {
                    b.Property<int>("RuleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Rule")
                        .IsRequired();

                    b.HasKey("RuleID");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("TournamentTracker.Models.TournamentModels.BestPainted", b =>
                {
                    b.Property<int>("BestPaintedID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventID");

                    b.Property<string>("FirstPlace")
                        .IsRequired();

                    b.Property<string>("SecondPlace");

                    b.Property<string>("ThirdPlace");

                    b.Property<string>("VotingUser")
                        .IsRequired();

                    b.HasKey("BestPaintedID");

                    b.HasIndex("EventID");

                    b.HasIndex("FirstPlace");

                    b.HasIndex("SecondPlace");

                    b.HasIndex("ThirdPlace");

                    b.HasIndex("VotingUser");

                    b.ToTable("BestPainted");
                });

            modelBuilder.Entity("TournamentTracker.Models.TournamentModels.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1500);

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("EventPackURL")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("EventRestrictions")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("FoodDescription")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int>("LocationID");

                    b.Property<int>("NumberOfTables");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("EventID");

                    b.HasIndex("LocationID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("TournamentTracker.Models.TournamentModels.EventArmyList", b =>
                {
                    b.Property<int>("EventArmyListID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventID");

                    b.Property<string>("List")
                        .HasAnnotation("MaxLength", 1500);

                    b.Property<string>("ListURL")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("UserID");

                    b.HasKey("EventArmyListID");

                    b.HasIndex("EventID");

                    b.HasIndex("UserID");

                    b.ToTable("EventArmyList");
                });

            modelBuilder.Entity("TournamentTracker.Models.TournamentModels.EventOrganiser", b =>
                {
                    b.Property<int>("EventOrganiserID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventID");

                    b.Property<string>("UserID");

                    b.HasKey("EventOrganiserID");

                    b.HasIndex("EventID");

                    b.HasIndex("UserID");

                    b.ToTable("EventOrganiser");
                });

            modelBuilder.Entity("TournamentTracker.Models.TournamentModels.EventPlayers", b =>
                {
                    b.Property<int>("EventPlayerID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventID");

                    b.Property<string>("Player")
                        .IsRequired();

                    b.HasKey("EventPlayerID");

                    b.HasIndex("EventID");

                    b.HasIndex("Player");

                    b.ToTable("EventPlayers");
                });

            modelBuilder.Entity("TournamentTracker.Models.TournamentModels.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("AddressLine2")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("County")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("FacebookURL")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("PhoneNumber")
                        .HasAnnotation("MaxLength", 14);

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("TwitterURL")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("WebsiteURL")
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("LocationID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TournamentTracker.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TournamentTracker.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TournamentTracker.Models.GameModels.Games", b =>
                {
                    b.HasOne("TournamentTracker.Models.GameModels.GamesRules", "GameRules")
                        .WithMany()
                        .HasForeignKey("GameRulesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.GameModels.GameScores", "GameScores")
                        .WithMany()
                        .HasForeignKey("GameScoreID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.ApplicationUser", "UserPlayer1")
                        .WithMany()
                        .HasForeignKey("Player1")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.ApplicationUser", "UserPlayer2")
                        .WithMany()
                        .HasForeignKey("Player2")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TournamentTracker.Models.GameModels.GameScores", b =>
                {
                    b.HasOne("TournamentTracker.Models.GameModels.Games", "game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.ApplicationUser", "UserPlayer2")
                        .WithMany()
                        .HasForeignKey("Player")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TournamentTracker.Models.GameModels.GamesRules", b =>
                {
                    b.HasOne("TournamentTracker.Models.GameModels.Rules", "PrimaryMission1Obj")
                        .WithMany()
                        .HasForeignKey("PrimaryMission1")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.GameModels.Rules", "PrimaryMission2Obj")
                        .WithMany()
                        .HasForeignKey("PrimaryMission2")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.GameModels.Rules", "SecondaryMission3Obj")
                        .WithMany()
                        .HasForeignKey("SecondaryMissio3");

                    b.HasOne("TournamentTracker.Models.GameModels.Rules", "SecondaryMission1Obj")
                        .WithMany()
                        .HasForeignKey("SecondaryMission1")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.GameModels.Rules", "SecondaryMission2Obj")
                        .WithMany()
                        .HasForeignKey("SecondaryMission2")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TournamentTracker.Models.TournamentModels.BestPainted", b =>
                {
                    b.HasOne("TournamentTracker.Models.TournamentModels.Event", "eventObj")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.ApplicationUser", "FirstPlaceUser")
                        .WithMany()
                        .HasForeignKey("FirstPlace")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.ApplicationUser", "SecondPlaceUser")
                        .WithMany()
                        .HasForeignKey("SecondPlace");

                    b.HasOne("TournamentTracker.Models.ApplicationUser", "ThirdPlaceUser")
                        .WithMany()
                        .HasForeignKey("ThirdPlace");

                    b.HasOne("TournamentTracker.Models.ApplicationUser", "VotingUserUser")
                        .WithMany()
                        .HasForeignKey("VotingUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TournamentTracker.Models.TournamentModels.Event", b =>
                {
                    b.HasOne("TournamentTracker.Models.TournamentModels.Location", "location")
                        .WithMany()
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TournamentTracker.Models.TournamentModels.EventArmyList", b =>
                {
                    b.HasOne("TournamentTracker.Models.TournamentModels.Event", "eventObj")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("TournamentTracker.Models.TournamentModels.EventOrganiser", b =>
                {
                    b.HasOne("TournamentTracker.Models.TournamentModels.Event", "eventObj")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("TournamentTracker.Models.TournamentModels.EventPlayers", b =>
                {
                    b.HasOne("TournamentTracker.Models.TournamentModels.Event", "eventObj")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TournamentTracker.Models.ApplicationUser", "PlayerUser")
                        .WithMany()
                        .HasForeignKey("Player")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
