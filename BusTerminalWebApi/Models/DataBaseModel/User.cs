using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTerminalWebApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public Guid AspUserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime UserBirthDate { get; set; }
        //
        public ICollection<Order> Orders { get; set; }
    }
}