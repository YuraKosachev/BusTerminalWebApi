using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BusTerminalWebApi.Models;

namespace BusTerminalWebApi.Context
{
    public class BusTerminalDbContext: DbContext
    {
        public BusTerminalDbContext() : base("BusTerminalConnection")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
    }
}