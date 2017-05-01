using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TournamentTracker.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index(string UserID)
        {
            //ToDO This whole controller lol
            return View();
        }
    }
}