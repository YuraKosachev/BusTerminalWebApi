using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BusTerminalWebApi.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }
        [Required]
        public string BusModel { get; set; }
        public string BusDescription { get; set; }
        [Required]
        public int BusNumberOfSeats { get; set; }
        //
        public virtual ICollection<Voyage> Voyages { get; set; }

    }
}