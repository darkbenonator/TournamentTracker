using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentTracker.Models.GameModels;

namespace TournamentTracker.SignalR
{
    public class HubHelper
    {
        private GamesRules GR;
        private int EventID;

        public void StartGame(int EventID, string UserID)
        {

        }

        public void GenerateOpponents(int round, int EventId)
        {
             
        }

        public string GetOpponentsList(string opponent )
        {
            return null;
        }

        public string GetPlayers()
        {
            return null;
        }



    }
}
