using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TournamentTracker.Data;
using TournamentTracker.Models.GameModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TounamentTracker.Hubs
{
    public class PlayHub : Hub
    {
        public void UpdateUsers(int EventID, PlayersList players)
        {
            using (var context = new ApplicationDbContext())
            {
                List<string> connectionIDs = (from CP in context.GameConnectedPlayers
                                              where CP.EventID == EventID
                                              select CP.ConnectionID).ToList();
                foreach (string ConnectionID in connectionIDs)
                {
                    Clients.User(ConnectionID).Update(JsonConvert.SerializeObject(players));
                }
            }
        }
        public void ConnectPlayer(string userID, int EventID)
        {
            using (var context = new ApplicationDbContext())
            {
                GameConnectedPlayers NewPlayer = new GameConnectedPlayers();
                NewPlayer.ConnectionID = Context.ConnectionId;
                NewPlayer.ConnectedTime = DateTime.Now;
                NewPlayer.Player = userID;
                NewPlayer.EventID = EventID;
                context.Add(NewPlayer);
                context.SaveChanges();
                PlayersList p = new PlayersList();
                p.playerList = (from U in context.Users
                                join EP in context.EventPlayers on U.Id equals EP.Player
                                join CP in context.GameConnectedPlayers on EP.EventID equals CP.EventID into CPL
                                from CP in CPL.DefaultIfEmpty()
                                where EP.EventID == EventID
                                select new Players()
                                {
                                    username = U.UserName,
                                    Firstname = U.Firstname,
                                    lastname = U.Lastname,
                                    active = CP == null ? false : true
                                }).ToList();

                UpdateUsers(EventID, p);
            }
        }
        
    }

    //public interface IPlayHub
    //{
    //    void Connect(string userID, int EventID);
    //    void Send(string players);
    //}
}
