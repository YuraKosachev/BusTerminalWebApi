using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTerminalWebApi.Models
{
    public class SearchParameter
    {
        public string DepartureBusStopName { get; set; }
        public string ArrivalBusStopName { get; set; }
        public DateTime VoyageDate { get; set; }
    }
}