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
        public JsonResult doesNameExist(string Name,  string Form)
        {
            var context = new ApplicationDbContext();
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.
            bool results = false;
            if (Form == "Location") {
                if (context.Location.Any(x => x.LocationName == Name)) {
                    results = true;
                }
            }
            else if(Form == "Event") {
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
            using (var context = new ApplicationDbContext())
            {
                EventViewModel eventVM = new EventViewModel();
                eventVM.evtTable = (from E in context.Event
                                    join l in context.Location on E.LocationID equals l.LocationID
                                    join EO in context.EventOrganiser on E.EventID equals EO.EventID
                                    join u in context.Users on EO.UserID equals u.Id
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
                                        EventOrganiser = EO.UserID
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
            return RedirectToAction("Index", "Tournament");
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
            return RedirectToAction( "CreateEvent", "Tournament");
        }

        //Get the events details
        public IActionResult EventDetails(int EventID)
        {
            using (var context = new ApplicationDbContext())
            {
                EventDetailsViewModel model = new EventDetailsViewModel();
                model = (from E in context.Event
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
                GamesViewModel games;
                 
                return View(model);
            }
            
        }

        //Edit the Event, Organiser Only.
        public IActionResult EditEvent(int EventID)
        {
            using (var context = new ApplicationDbContext())
            {
                Event model = new Event();
                model = (from E in context.Event
                         where E.EventID == EventID
                         select E
                         ).First();
                return View(model);
            }
        }

        //Get The Events Games. Ajax
        public JsonResult EventGames(int EventID)
        {
            string test = "Hi";
            return Json(test);
        }
        //Add Game
        public JsonResult AddGames(int EventID)
        {
            string test = "Hi";
            return Json(test);
        }
    }
}