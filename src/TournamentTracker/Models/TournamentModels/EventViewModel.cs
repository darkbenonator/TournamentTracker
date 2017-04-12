using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentTracker.Models.GameModels;

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
            public string LocationCity { get; set; }
            public string EventName { get; set; }
            public string Description { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public int EventID { get; set; }
            public string EventOrganiser { get; set; }
            public bool SignedUp { get; set; }
        }
    }

    public class LocationDropDown
    {
        public int ID { get; set; }
        public string locationName { get; set; }
    }

    public class EventDetailsViewModel
    {
        public string LocationName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FacebookURL { get; set; }
        public string WebsiteURL { get; set; }
        public string TwitterURL { get; set; }
        public string Email { get; set; }

        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string EventPackURL { get; set; }
        public int NumberOfTables { get; set; }
        public string EventRestrictions { get; set; }
        public string FoodDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EventOrganiserID { get; set; }
    }

    public class EventDetailsGameViewModel
    {
        public EventDetailsViewModel Event { get; set; }
        public IList<GamesViewModel> GamesViewList { get; set; }
    }

    public class GamesEdit
    {
        public List<GamesRules> GamesViewList { get; set; }
    }
}
