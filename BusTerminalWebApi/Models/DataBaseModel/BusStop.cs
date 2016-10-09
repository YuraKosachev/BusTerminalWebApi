using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTerminalWebApi.Models
{
    public class BusStop
    {
        [Key]
        public int BusStopId { get; set; }
        public string BusStopName { get; set; }
        public string BusStopDescrition { get; set; }
        //
        public virtual ICollection<Voyage> Voyage { get; set; }
    }
}