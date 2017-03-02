using System;
using System.Linq;

namespace TournamentTracker.Controllers
{
    internal class CheckOwner
    {
        internal static bool IsOwner(string userID, int eventID)
        {
            using (var context = new Data.ApplicationDbContext())
            {

                if (!(from EO in context.EventOrganiser where EO.EventID == eventID where EO.UserID == userID select EO).Any()) {
                    return false;
                }
                else {
                    return true;
                }
            }
        }
    }
}