using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTerminalWebApi.Models
{
    public class Voyage
    {
        [Key]
        public int VoyageId { get; set; }
        //[ForeignKey("DepartureBusStop")]
        public int DepartureBusStopId { get; set; }
        //[ForeignKey("ArrivalBusStop")]
        public int ArrivalBusStopId { get; set; }
       // [ForeignKey("Bus")]
        public int BusId { get; set; }
        public string VoyageName { get; set; }
        public DateTime VoyageDate { get; set; }
        public decimal TicketCost { get; set; }
        //
        public virtual BusStop ArrivalBusStop { get; set; }
        public virtual BusStop DepartureBusStop { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Bus Bus { get; set; }
    }
}