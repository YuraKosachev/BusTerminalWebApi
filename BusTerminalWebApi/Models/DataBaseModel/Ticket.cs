using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTerminalWebApi.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public string PassengerFirstName { get; set; }
        public string PassengerLastName { get; set; }
        public string PassengerDocumentNumber { get; set; }
        public int PassengerSeatNumber { get; set; }
        //
        //[ForeignKey("Order")]
        //public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}