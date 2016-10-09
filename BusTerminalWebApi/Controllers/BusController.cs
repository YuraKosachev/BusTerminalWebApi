using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusTerminalWebApi.Context;
using BusTerminalWebApi.Models;

namespace BusTerminalWebApi.Controllers
{
    [Authorize]
    public class BusController : ApiController
    {
        private BusTerminalDbContext Context { get; set; }

        public BusController() {
            Context = new BusTerminalDbContext();
        }
        // GET: api/Bus
        public IEnumerable<BusViewModel> GetBuses()
        {
            return Context.Buses.Select(bus=>new BusViewModel {
                BusId= bus.BusId,
                BusDescription = bus.BusDescription,
                BusModel = bus.BusModel,
                BusNumberOfSeats = bus.BusNumberOfSeats 
            });
        }

        // GET: api/Bus/5
        [ResponseType(typeof(Bus))]
        public IHttpActionResult GetBus(int id)
        {
            Bus bus = Context.Buses.Find(id);
            if (bus == null)
            {
                return NotFound();
            }

            return Ok(new BusViewModel {
                BusId = bus.BusId,
                BusModel = bus.BusModel,
                BusDescription = bus.BusDescription,
                BusNumberOfSeats = bus.BusNumberOfSeats
            });
        }

        // PUT: api/Bus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBus(int id, Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bus.BusId)
            {
                return BadRequest();
            }

            Context.Entry(bus).State = EntityState.Modified;

            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Bus
        [ResponseType(typeof(Bus))]
        public IHttpActionResult PostBus(Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Context.Buses.Add(bus);
            Context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bus.BusId }, bus);
        }

        // DELETE: api/Bus/5
        [ResponseType(typeof(Bus))]
        public IHttpActionResult DeleteBus(int id)
        {
            Bus bus = Context.Buses.Find(id);
            if (bus == null)
            {
                return NotFound();
            }

            Context.Buses.Remove(bus);
            Context.SaveChanges();

            return Ok(new BusViewModel
            {
                BusId = bus.BusId,
                BusModel = bus.BusModel,
                BusDescription = bus.BusDescription,
                BusNumberOfSeats = bus.BusNumberOfSeats
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusExists(int id)
        {
            return Context.Buses.Count(e => e.BusId == id) > 0;
        }
    }
}