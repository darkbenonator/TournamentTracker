using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TournamentTracker.Data;

namespace TournamentTracker.Models.TournamentModels
{
    public class Location
    {
        [Key()]
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }

    public class Event
    {
        [Key()]
        public int EventID  { get; set; }
        public int LocationID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string EventPackURL { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [ForeignKey("LocationID")]
        public Location location { get; set; }
    }

    public class EventOrganiser
    {
        [Key()]
        public int EventOrganiserID { get; set; }
        public string UserID { get; set; }
        public int EventID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("EventID")]
        public Event eventObj { get; set; }
    }
}
