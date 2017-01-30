using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentTracker.Models.TournamentModels
{
    //Events Table
    public class EventViewModel
    {
        public IList<EventTable> evtTable;
        public class EventTable
        {
            public int LocationID { get; set; }
            public string LocationName { get; set; }
            public string EventName { get; set; }
            public string Description { get; set; }
            public DateTime StartTime { get; set; }
            public string UserID { get; set; }
            public int EventID { get; set; }
            public string Username { get; set; }
        }
    }

    //Location Dropdown
    public class LocationsDropDown
    {
        public IList<Location>locations;
    }

}
