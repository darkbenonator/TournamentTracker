using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TournamentTracker.Models.GameModels;
using TournamentTracker.Data;

namespace TournamentTracker.Controllers
{
    public class PlayController : Controller
    {
        [Authorize]
        public IActionResult Index(int EventID)
        {
            using (var context = new ApplicationDbContext())
            {
                PlayStart Games = new PlayStart();
                int Rounds = (from GR in context.GamesRules
                              where GR.EventID == EventID
                              orderby GR.Round
                              select GR.Round).FirstOrDefault();


                if (Rounds > 0)
                {
                    int i = 0;
                    while (i <= Rounds)
                    {
                        GamesViewModel games = (from GR in context.GamesRules
                                                join Mis1 in context.Rules on GR.PrimaryMission1 equals Mis1.RuleID
                                                join Mis2 in context.Rules on GR.PrimaryMission2 equals Mis2.RuleID
                                                join Sec1 in context.Rules on GR.SecondaryMission1 equals Sec1.RuleID
                                                join Sec2 in context.Rules on GR.SecondaryMission2 equals Sec2.RuleID
                                                join Sec3 in context.Rules on GR.SecondaryMission3 equals Sec3.RuleID
                                                where GR.EventID == EventID
                                                where GR.Round == i
                                                select new GamesViewModel()
                                                {
                                                    Round = GR.Round,

                                                    PrimaryMissionRuleName = Mis1.RuleName,
                                                    PrimaryMissionRule = Mis1.Rule,
                                                    Primary2MissionRuleName = Mis2.RuleName,
                                                    Primary2MissionRule = Mis2.Rule,
                                                    PrimaryMissionWinScore = GR.PrimaryMissionWinScore,
                                                    PrimaryMissionDrawScore = GR.PrimaryMissionDrawScore,

                                                    SecondaryMissionRuleName = Sec1.RuleName,
                                                    SecondaryMissionRule = Sec1.Rule,
                                                    Secondary2MissionRuleName = Sec2.RuleName,
                                                    Secondary2MissionRule = Sec2.Rule,
                                                    Secondary3MissionRuleName = Sec3.RuleName,
                                                    Secondary3MissionRule = Sec3.Rule,
                                                    SecondaryMissionDrawScore = GR.SecondaryMissionDrawScore,
                                                    SecondaryMissionWinScore = GR.SecondaryMissionWinScore
                                                }
                                                ).First();
                        Games.GameRules.Add(games);
                        i++;

                    }
                }
                Games.OrganiserID = (from EO in context.EventOrganiser
                                     where EO.EventID == EventID
                                     select EO.UserID).First();
                return View("Play", Games);  
            }
        }
    }
}