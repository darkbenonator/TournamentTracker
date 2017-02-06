using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentTracker.Models.GameModels
{
    public class Rules
    {
        [Key()]
        public int RuleID { get; set; }
        [Required]
        public string Rule { get; set; }
    }
    public class GamesRules
    {
        [Key()]
        public int GameRulesID { get; set; }
        [Required]
        public int PrimaryMission1 { get; set; }
        [Required]
        public int PrimaryMissionWinScore { get; set; }
        [Required]
        public int PrimaryMissionDrawScore { get; set; }
        public int PrimaryMission2 { get; set; }
        public int SecondaryMission1 { get; set; }
        public int SecondaryMission2 { get; set; }
        public int SecondaryMission3 { get; set; }
        public int ExtraRules { get; set; }
        [ForeignKey("PrimaryMission1")]
        public Rules PrimaryMission1Obj { get; set; }
        [ForeignKey("PrimaryMission2")]
        public Rules PrimaryMission2Obj { get; set; }
        [ForeignKey("SecondaryMission1")]
        public Rules SecondaryMission1Obj { get; set; }
        [ForeignKey("SecondaryMission2")]
        public Rules SecondaryMission2Obj { get; set; }
        [ForeignKey("SecondaryMissio3")]
        public Rules SecondaryMission3Obj { get; set; }
    }

    public class Games
    {
        [Key()]
        public int GameID { get; set; }
        public TimeSpan GameLength { get; set; }
        [Required]
        public string Player1 { get; set; }
        [Required]
        public string Player2 { get; set; }
        [Required]
        public int Round { get; set; }
        [Required]
        public int Table { get; set; }
        [Required]
        public int GameScoreID { get; set; }
        [ForeignKey("GameScoreID")]
        public GameScores GameScores { get; set; }
        public int GameRulesID { get; set; }
        [ForeignKey("GameRulesID")]
        public GamesRules GameRules  { get; set; }
        [ForeignKey("Player1")]
        public virtual ApplicationUser UserPlayer1 { get; set; }
        [ForeignKey("Player2")]
        public virtual ApplicationUser UserPlayer2 { get; set; }
    }

    public class GameScores
    {
        [Key()]
        public int GameScoreID { get; set; }
        [Required]
        public int GameID { get; set; }
        [Required]
        public string Player { get; set; }
        [Required]
        public int PrimaryScore { get; set; }
        public int Primary2Score { get; set; }
        public int SecondaryScore { get; set; }
        public int SportsmanScore { get; set; }
        [ForeignKey("GameID")]
        public Games game { get; set; }
        [ForeignKey("Player")]
        public virtual ApplicationUser UserPlayer2 { get; set; }
    }
}
