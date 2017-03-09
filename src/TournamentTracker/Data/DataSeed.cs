using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentTracker.Models.GameModels;

namespace TournamentTracker.Data
{
    public class DataSeed
    {
        public void SeedRules()
        {
            //TODO:Add Rules
            using (var context = new ApplicationDbContext())
            {
                if (!context.Rules.Any())
                {
                    Rules[] rules =
                    {
                       new Rules
                       {
                           RuleName = "Slay The Warlord",
                           Rule = "Kill the enemies commander"
                       },
                       new Rules
                       {
                           RuleName = "First Blood",
                           Rule = "Kill the first unit"
                       }
                    };
                    foreach (Rules rule in rules)
                    {

                        context.Add(rule);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
