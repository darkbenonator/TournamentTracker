using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TournamentTracker.Models.TournamentModels;

namespace TournamentTracker.Models.GameModels
{
    public class Rules
    {
        [Key()]
        public int RuleID { get; set; }
        [Required, StringLength(35, MinimumLength = 3)]
        [RegularExpression(@"^([\w\s\.])*$", ErrorMessage = "Please use alphanumeric characters, spaces are allowed")]
        public string RuleName { get; set; }
        [StringLength(200)]
        [RegularExpression(@"^([\w\s\.@!$&*();:'/+,-?]*$)", ErrorMessage = "Contains Illegal characters")]
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
        [Required]
        public TimeSpan GameLength { get; set; }
        [Required]
        public int Round { get; set; }
        public int PrimaryMission2 { get; set; }
        public int SecondaryMissionWinScore { get; set; }
        public int SecondaryMissionDrawScore { get; set; }
        public int SecondaryMission1 { get; set; }
        public int SecondaryMission2 { get; set; }
        public int SecondaryMission3 { get; set; }
        public int EventID { get; set; }
        [StringLength(200)]
        [RegularExpression(@"^([\w\s\.@!$&*();:'/+,-?]*$)", ErrorMessage = "Contains Illegal characters")]
        public string ExtraRules { get; set; }
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
        [ForeignKey("EventID")]
        public Event eventObj { get; set; }
    }

    public class Games
    {
        [Key()]
        public int GameID { get; set; }
        public TimeSpan GameLength { get; set; }
        public TimeSpan CurrentGameTime { get; set; }
        [Required]
        public string Player1 { get; set; }
        [Required]
        public string Player2 { get; set; }
        [Required]
        public int Table { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        [ForeignKey("Player1Score")]
        public GameScores Player1ScoreObj { get; set; }
        [ForeignKey("Player2Score")]
        public GameScores Player2ScoreObj { get; set; }
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
        public string Player { get; set; }
        [Required]
        public int PrimaryScore { get; set; }
        public int Primary2Score { get; set; }
        public int SecondaryScore { get; set; }
        [Required]
        public int SportsmanScore { get; set; }
        [ForeignKey("Player")]
        public virtual ApplicationUser PlayerObj { get; set; }
    }
}
