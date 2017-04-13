using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TournamentTracker.Models.TournamentModels;
using TournamentTracker.Data;
using static TournamentTracker.Models.TournamentModels.EventViewModel;
using Microsoft.AspNetCore.Identity;
using TournamentTracker.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;
using TournamentTracker.Models.GameModels;
using System;

namespace TournamentTracker.Controllers
{
    public class TournamentController : Controller
    {


        private readonly UserManager<ApplicationUser> _userManager;

        public TournamentController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //Checks to see if the name being entered is unique, Used for Location and Event names.
        [HttpPost]
        public JsonResult doesNameExist(string Name, string Form)
        {
            var context = new ApplicationDbContext();
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.
            bool results = false;
            if (Form == "Location")
            {
                if (context.Location.Any(x => x.LocationName == Name))
                {
                    results = true;
                }
            }
            else if (Form == "Event")
            {
                if (context.Event.Any(x => x.EventName == Name))
                {
                    results = true;
                }
            }
            return Json(results);
        }

        //Home Loads the events table 
        [Authorize]
        public IActionResult Index()
        {
            string UserID = _userManager.GetUserId(HttpContext.User);
            using (var context = new ApplicationDbContext())
            {
                EventViewModel eventVM = new EventViewModel();
                eventVM.evtTable = (from E in context.Event
                                    join l in context.Location on E.LocationID equals l.LocationID
                                    join EO in context.EventOrganiser on E.EventID equals EO.EventID
                                    join u in context.Users on EO.UserID equals u.Id
                                    join sn in context.EventPlayers  on new
                                    {
                                        Key1 = E.EventID,
                                        Key2 = UserID
                                    } equals new
                                    {
                                        Key1 = sn.EventID,
                                        Key2 = sn.Player
                                    } into lt
                                    from sn in lt.DefaultIfEmpty()
                                    select (new EventTable()
                                    {
                                        EventID = E.EventID,
                                        Description = E.Description,
                                        EventName = E.EventName,
                                        LocationName = l.LocationName,
                                        LocationID = l.LocationID,
                                        StartTime = E.StartTime,
                                        EndTime = E.EndTime,
                                        LocationCity = l.City,
                                        EventOrganiser = EO.UserID,
                                        SignedUp = sn == null ? false : true
                                    })).ToList();
                return View("Events", eventVM);
            }
        }

        //Create Event 
        [Authorize]
        public IActionResult CreateEvent()
        {
            using (var context = new ApplicationDbContext())
            {
                Event model = new Event();
                var query = (from L in context.Location
                             select L).ToList();
                ViewBag.Locations = new SelectList(query, "LocationID", "LocationName");

                return View("CreateEvent", model);
            }
        }

        //Create Event 
        [Authorize]
        public RedirectToActionResult Create(Event eventCreation)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Add(eventCreation);
                EventOrganiser EO = new EventOrganiser();
                EO.EventID = eventCreation.EventID;
                EO.UserID = _userManager.GetUserId(HttpContext.User);
                context.Add(EO);
                context.SaveChanges();
            }
            return RedirectToAction("EditEvent", "Tournament", eventCreation);
        }

        //Load the location creation screen
        //Add new Location, Admin only?
        [Authorize]
        public ActionResult AddLocation()
        {
            var model = new Location();
            return View("CreateLocation", model);
        }

        //Add new Location, Admin only?
        [Authorize]
        public RedirectToActionResult CreateLocation(Location locationCreation)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Add(locationCreation);
                LocationAdmin admin = new LocationAdmin();
                admin.UserID = _userManager.GetUserId(HttpContext.User);
                admin.LocationID = locationCreation.LocationID;
                context.Add(admin);
                context.SaveChanges();
            }
            return RedirectToAction("CreateEvent", "Tournament");
        }

        //Get the events details
        public IActionResult EventDetails(int EventID)
        {
            using (var context = new ApplicationDbContext())
            {
                //The events details
                EventDetailsViewModel EventDetails = new EventDetailsViewModel();
                EventDetails = (from E in context.Event
                                join L in context.Location on E.LocationID equals L.LocationID
                                join EO in context.EventOrganiser on E.EventID equals EO.EventID
                                where E.EventID == EventID
                                select (new EventDetailsViewModel()
                                {
                                    LocationName = L.LocationName,
                                    AddressLine1 = L.AddressLine1,
                                    AddressLine2 = L.AddressLine2,
                                    City = L.City,
                                    County = L.County,
                                    Email = L.Email,
                                    FacebookURL = L.FacebookURL,
                                    PhoneNumber = L.PhoneNumber,
                                    PostCode = L.PostCode,
                                    TwitterURL = L.TwitterURL,
                                    WebsiteURL = L.WebsiteURL,

                                    EventOrganiserID = EO.UserID,

                                    Description = E.Description,
                                    EndTime = E.EndTime,
                                    StartTime = E.StartTime,
                                    EventName = E.EventName,
                                    EventPackURL = E.EventPackURL,
                                    EventRestrictions = E.EventRestrictions,
                                    FoodDescription = E.FoodDescription,
                                    NumberOfTables = E.NumberOfTables
                                })).First();
                int Rounds = (from GR in context.GamesRules
                              where GR.EventID == EventID
                              orderby GR.Round
                              select GR.Round).FirstOrDefault();

                int i = 0;
                //The view model
                EventDetailsGameViewModel GL = new EventDetailsGameViewModel();
                GL.Event = EventDetails;
                //Each round of the event
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
                    GL.GamesViewList.Add(games);
                    i++;
                }
                GL.EventPlayers = (from ep in context.EventPlayers
                                   join u in context.Users on ep.Player equals u.Id
                                   where ep.EventID == EventID
                                   select new EventPlayersModel
                                   {
                                       UserID = u.Id,
                                       Username = u.UserName
                                   }
                                   ).ToList();
                //Signed up players
                string UserID = _userManager.GetUserId(HttpContext.User);
                if (GL.EventPlayers.Any(x => x.UserID == UserID))
                {
                    GL.SignedUp = true;
                }
                else
                {
                    GL.SignedUp = false;
                }

                return View(GL);
            }

        }

        //Edit the Event, Organiser Only.
        [Authorize]
        public IActionResult EditEvent(int EventID)
        {
            if (!CheckOwner.IsOwner(_userManager.GetUserId(HttpContext.User), EventID))
            {
                return this.Index();
            }
            using (var context = new ApplicationDbContext())
            {
                var query = (from L in context.Location
                             select L).ToList();
                Event model = (from E in context.Event where E.EventID == EventID select E).First();
                ViewBag.Locations = new SelectList(query, "LocationID", "LocationName");
                return View(model);
            }
        }

        [Authorize]
        public ActionResult AddGame(int EventID)
        {
            var model = new GamesRules();
            using (var context = new ApplicationDbContext())
            {
                var GameRules = (from GR in context.Rules
                                 select GR).ToList();
                int Round = (from GR in context.GamesRules
                             orderby GR.Round descending
                             select GR.Round).FirstOrDefault();
                ViewBag.Round = Round + 1;
                ViewBag.GameRulesDropDown = new SelectList(GameRules, "RuleID", "RuleName");
                ViewBag.EventID = EventID;
            }
            return View(model);
        }

        [Authorize]
        public ActionResult EditGame(int EventID)
        {
            using (var context = new ApplicationDbContext())
            {
                GamesEdit model = new GamesEdit();
                model.GamesViewList = (from GR in context.GamesRules where GR.EventID == EventID select GR).ToList();
                return View(model);
            }
        }

        [Authorize]
        public ActionResult LoadAddRule(int EventID)
        {
            var model = new Rules();
            ViewBag.EventID = EventID;
            return View("AddRule", model);
        }

        [Authorize]
        public void CreateGame(GamesRules CreatedGame)
        {
            if (CheckOwner.IsOwner(_userManager.GetUserId(HttpContext.User), CreatedGame.EventID))
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Add(CreatedGame);
                    context.SaveChanges();
                }
            }
        }

        [Authorize]
        public void CreateRule(int id,Rules Rule)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Add(Rule);
                context.SaveChanges();
            }
            AddGame(id);
        }

        [Authorize]
        public void SignUpToEvent(int EventID)
        {
            using (var context = new ApplicationDbContext())
            {
                EventPlayers Players = new EventPlayers();
                Players.EventID = EventID;
                Players.Player = _userManager.GetUserId(HttpContext.User);
                context.Add(Players);
                context.SaveChanges();
            }
        }

        [Authorize]
        public void UnsubscribeToEvent(int EventID, string UserID = "")
        {
            using (var context = new ApplicationDbContext())
            {
                EventPlayers players = new EventPlayers();
                players.EventID = EventID;
                // If the UserID is not empty an EventManager is removing the User from the Event
                if (!UserID.Equals(""))
                {
                    players.Player = UserID;        
                }
                else
                {
                    players.Player = _userManager.GetUserId(HttpContext.User);
                }
                context.Attach(players);
                context.Remove(players);
            }
        }
    }
}