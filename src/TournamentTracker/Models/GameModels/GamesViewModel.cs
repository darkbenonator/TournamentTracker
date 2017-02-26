using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentTracker.Models.GameModels
{
    public class GamesViewModel
    {
        public int Round { get; set; }
        public string PrimaryMissionRuleName { get; set; }
        public string PrimaryMissionRule { get; set; }
        public string Primary2MissionRuleName { get; set; }
        public string Primary2MissionRule { get; set; }
        public string SecondaryMissionRuleName { get; set; }
        public string SecondaryMissionRule { get; set; }
        public string Secondary2MissionRuleName { get; set; }
        public string Secondary2MissionRule { get; set; }
        public string Secondary3MissionRuleName { get; set; }
        public string Secondary3MissionRule { get; set; }
        public int PrimaryMissionWinScore { get; set; }
        public int PrimaryMissionDrawScore { get; set; }
        public int SecondaryMissionWinScore { get; set; }
        public int SecondaryMissionDrawScore { get; set; }
        public TimeSpan GameLength { get; set; }

    }


}
