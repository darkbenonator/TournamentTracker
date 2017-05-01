using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TournamentTracker.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using TournamentTracker.Models.TournamentModels;
using TournamentTracker.Models.GameModels;

namespace TournamentTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //DbContextOptions<ApplicationDbContext> options
        public ApplicationDbContext()
            : base()
            //options
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();
            optionsBuilder.UseSqlServer(connectionStringConfig.GetConnectionString("Database"));
        }
        public DbSet<Location> Location { get; set; }
        public DbSet<LocationAdmin> LocationAdmin { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventOrganiser> EventOrganiser { get; set; }
        public DbSet<EventArmyList> EventArmyList { get; set; }
        public DbSet<EventPlayers> EventPlayers { get; set; }
        public DbSet<BestPainted> BestPainted { get; set; }
        public DbSet<Rules> Rules { get; set; }
        public DbSet<GamesRules> GamesRules { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<GameScores> GameScores { get; set; }
        public DbSet<GameConnectedPlayers>GameConnectedPlayers { get; set; }
    }
}
