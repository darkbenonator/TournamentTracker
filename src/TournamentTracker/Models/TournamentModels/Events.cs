using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentTracker.Data;

namespace TournamentTracker.Models.TournamentModels
{
    public class Events
    {
        public string EventOrganiserID { get; set; }

        public string UserID { get; set; }
        public string EventID { get; set; }

        public ApplicationUser User { get; set; }

    }
}
