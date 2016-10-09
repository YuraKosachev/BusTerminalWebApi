using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTerminalWebApi.Models
{
    public class BusViewModel
    {
        public int BusId { get; set; }
        public string BusModel { get; set; }
        public string BusDescription { get; set; }
        public int BusNumberOfSeats { get; set; }
    }
}