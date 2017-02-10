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
                                        UserID = u.Id,
                                        Username = u.UserName,
                                        EventID = E.EventID,
                                        Description = E.Description,
                                        EventName = E.EventName,
                                        LocationName = l.LocationName,
                                        LocationID = l.LocationID,
                                        StartTime = E.StartTime
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
                var query = from L in context.Location
                            select L;
                ViewBag.Locations = new SelectList(query, "LocationName", "LocationID");

                return View("CreateEvent", model);
            }
        }

        //Create Event 
        [Authorize]
        public void Create(Event eventCreation)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Add(eventCreation);
                context.SaveChanges();
                EventOrganiser EO = new EventOrganiser();
                EO.EventID = eventCreation.EventID;
                EO.UserID = _userManager.GetUserId(HttpContext.User);
            }
            Index();
        }

        //Load the location creation screen
        //Add new Location, Admin only?
        [Authorize]
        public ActionResult AddLocation()
        {
            var model = new Location();
            return PartialView("CreateLocation", model);
        }
        //Add new Location, Admin only?
        [Authorize]
        public void CreateLocation(Location locationCreation)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Add(locationCreation);
                context.SaveChanges();
            }
            Index();
        }

    }
}