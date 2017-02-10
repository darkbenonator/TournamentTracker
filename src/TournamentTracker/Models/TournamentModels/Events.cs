using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TournamentTracker.Models.TournamentModels
{
    public class Location
    {
        [Key()]
        public int LocationID { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        public string County { get; set; }
        [Required]
        public string PostCode { get; set; }
    }

    public class Event
    {
        [Key()]
        public int EventID  { get; set; }
        public int LocationID { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string Description { get; set; }
        public string EventPackURL { get; set; }
        [Required]
        public string NumberOfTables { get; set; }
        public string EventRestrictions { get; set; }
        public string FoodDescription { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [ForeignKey("LocationID")]
        public Location location { get; set; }
    }
    
    public class EventArmyList
    {
        public int EventArmyListID { get; set; }
        public string UserID { get; set; }
        public int EventID { get; set; }
        public string ListURL { get; set; }
        public string List { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("EventID")]
        public Event eventObj { get; set; }
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

    public class EventPlayers
    {
        [Key()]
        public int EventPlayerID { get; set; }
        public int EventID { get; set; }
        [Required]
        public string Player { get; set; }
        [ForeignKey("EventID")]
        public Event eventObj { get; set; }
        [ForeignKey("Player")]
        public virtual ApplicationUser PlayerUser { get; set; }
    }

    public class BestPainted
    {
        [Key()]
        public int BestPaintedID { get; set; }
        [Required]
        public int EventID { get; set; }
        [Required]
        public string VotingUser { get; set; }
        [Required]
        public string FirstPlace { get; set; }
        public string SecondPlace { get; set; }
        public string ThirdPlace { get; set; }
        [ForeignKey("EventID")]
        public Event eventObj { get; set; }
        [ForeignKey("VotingUser")]
        public virtual ApplicationUser VotingUserUser { get; set; }
        [ForeignKey("FirstPlace")]
        public virtual ApplicationUser FirstPlaceUser { get; set; }
        [ForeignKey("SecondPlace")]
        public virtual ApplicationUser SecondPlaceUser { get; set; }
        [ForeignKey("ThirdPlace")]
        public virtual ApplicationUser ThirdPlaceUser { get; set; }
    }
}
