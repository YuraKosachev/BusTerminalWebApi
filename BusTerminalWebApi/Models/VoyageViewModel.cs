using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTerminalWebApi.Models
{
    public class VoyageViewModel
    {
        public int VoyageId { get; set; }
        public BusStop DepartureBusStop { get; set; }
        public BusStop ArrivalBusStopId { get; set; }
        public Bus Bus { get; set; }
        public string VoyageName { get; set; }
        public DateTime VoyageDate { get; set; }
        public int NumberOfSeats { get; set;}
        public int NumberOfRemainingSeats { get; set; }
        public decimal TicketCost { get; set; }

    }
}