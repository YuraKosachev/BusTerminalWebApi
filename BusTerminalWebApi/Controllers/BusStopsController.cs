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
    public class BusStopsController : ApiController
    {
        private BusTerminalDbContext Context { get; set; }

        public BusStopsController() {
            Context = new BusTerminalDbContext();
        }
        // GET: api/BusStops
        public IEnumerable<BusStop> GetBusStops()
        {
            return Context.BusStops;
        }

        // GET: api/BusStops/5
        [ResponseType(typeof(BusStop))]
        public IHttpActionResult GetBusStop(int id)
        {
            BusStop busStop = Context.BusStops.Find(id);
            if (busStop == null)
            {
                return NotFound();
            }

            return Ok(busStop);
        }

        // PUT: api/BusStops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusStop(int id, BusStop busStop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != busStop.BusStopId)
            {
                return BadRequest();
            }

            Context.Entry(busStop).State = EntityState.Modified;

            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusStopExists(id))
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

        // POST: api/BusStops
        [ResponseType(typeof(BusStop))]
        public IHttpActionResult PostBusStop(BusStop busStop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Context.BusStops.Add(busStop);
            Context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = busStop.BusStopId }, busStop);
        }

        // DELETE: api/BusStops/5
        [ResponseType(typeof(BusStop))]
        public IHttpActionResult DeleteBusStop(int id)
        {
            BusStop busStop = Context.BusStops.Find(id);
            if (busStop == null)
            {
                return NotFound();
            }

            Context.BusStops.Remove(busStop);
            Context.SaveChanges();

            return Ok(busStop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusStopExists(int id)
        {
            return Context.BusStops.Count(e => e.BusStopId == id) > 0;
        }
    }
}