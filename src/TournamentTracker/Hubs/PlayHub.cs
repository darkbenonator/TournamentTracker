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
        //Updates the users with who is logged in
        //Test with all
        public void UpdateUsers(int EventID, PlayersList players)
        {
            using (var context = new ApplicationDbContext())
            {
                List<string> connectionIDs = (from CP in context.GameConnectedPlayers
                                              where CP.EventID == EventID
                                              select CP.ConnectionID).ToList();
                foreach (string ConnectionID in connectionIDs)
                {
                    Clients.Client(Context.ConnectionId).test(JsonConvert.SerializeObject(players.playerList));
                }
            }
        }
        //This is called upon the web page being loaded and adds a connection string for the player into the database [GameConnectedPlayers]
        public void ConnectPlayer(string userID, int EventID)
        {
            using (var context = new ApplicationDbContext())
            {
                GameConnectedPlayers Existing = new GameConnectedPlayers();
                Existing = (from CEP in context.GameConnectedPlayers
                            where CEP.EventID == EventID
                            where CEP.Player == userID
                            select new GameConnectedPlayers
                            {
                                Player = CEP.Player,
                                ConnectionID = CEP.ConnectionID,
                                ConnectedTime = CEP.ConnectedTime,
                                EventID = EventID,
                                DisconnectedTime = CEP.DisconnectedTime
                            }).FirstOrDefault();
                if (Existing != null)
                {
                    GameConnectedPlayers Updated = Existing;
                    Updated.ConnectionID = Context.ConnectionId;
                    Updated.ConnectedTime = DateTime.Now;
                    context.Entry(Existing).CurrentValues.SetValues(Updated);
                }
                else
                {
                    GameConnectedPlayers NewPlayer = new GameConnectedPlayers();
                    NewPlayer.ConnectionID = Context.ConnectionId;
                    NewPlayer.ConnectedTime = DateTime.Now;
                    NewPlayer.Player = userID;
                    NewPlayer.EventID = EventID;
                    context.Add(NewPlayer);
                    context.SaveChanges();
                }
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

        public override Task OnDisconnected(bool stopCalled)
        {
            using (var context = new ApplicationDbContext())
            {
                GameConnectedPlayers NewPlayer = new GameConnectedPlayers();
                NewPlayer = (from CP in context.GameConnectedPlayers
                             where CP.ConnectionID == Context.ConnectionId
                             select CP).FirstOrDefault();
                if (NewPlayer != null)
                {
                    context.Remove(NewPlayer);
                    context.SaveChanges();
                }
            }
            return base.OnDisconnected(stopCalled);
        }
    }

}

    //public interface IPlayHub
    //{
    //    void Connect(string userID, int EventID);
    //    void Send(string players);
    //}
