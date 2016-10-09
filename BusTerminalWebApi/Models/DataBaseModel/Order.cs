using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTerminalWebApi.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        //[ForeignKey("User")]
        public int UserId { get; set; }
        //[ForeignKey("Voyage")]
        public int VoyageId { get; set; }
        //[ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public int StatusOrder { get; set; }
        
        //
        public virtual User User { get; set; }
       public virtual ICollection<Ticket> Tickets { get; set; }
       public virtual Voyage Voyage { get; set; }

    }
}