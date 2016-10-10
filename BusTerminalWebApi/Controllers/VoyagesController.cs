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
    [RoutePrefix("api/Voyage")]
    public class VoyagesController : ApiController
    {
        private BusTerminalDbContext Context { get; set; } 

        public VoyagesController() {
            Context = new BusTerminalDbContext();
        }

        // GET: api/Voyages
        [Route("AllVoyages")]
        public IEnumerable<VoyageViewModel> GetVoyages()
        {
            return Context.Voyages.Select(voyage => new VoyageViewModel
            {
                VoyageId = voyage.VoyageId,
                VoyageName = voyage.VoyageName,
                VoyageDate = voyage.VoyageDate,
                ArrivalBusStop = Context.BusStops.First(busStop => busStop.BusStopId.Equals(voyage.ArrivalBusStopId)),
                DepartureBusStop = Context.BusStops.First(busStop => busStop.BusStopId.Equals(voyage.DepartureBusStopId)),
                Bus = Context.Buses.First(bus => bus.Equals(voyage.BusId)),
                TicketCost = voyage.TicketCost

            });
        }

        // GET: api/Voyages
        [Route("AllVoyages/Search")]
        public IEnumerable<VoyageViewModel> GetVoyages(SearchParameter searchParameter )
        {
            return Context.Voyages.Select(voyage => new VoyageViewModel
            {
                VoyageId = voyage.VoyageId,
                VoyageName = voyage.VoyageName,
                VoyageDate = voyage.VoyageDate,
                ArrivalBusStop = Context.BusStops.First(busStop => busStop.BusStopId.Equals(voyage.ArrivalBusStopId)),
                DepartureBusStop = Context.BusStops.First(busStop => busStop.BusStopId.Equals(voyage.DepartureBusStopId)),
                Bus = Context.Buses.First(bus => bus.Equals(voyage.BusId)),
                TicketCost = voyage.TicketCost

            });
        }

        // GET: api/Voyages/5
        [ResponseType(typeof(Voyage))]
        public IHttpActionResult GetVoyage(int id)
        {
            Voyage voyage = Context.Voyages.Find(id);
            if (voyage == null)
            {
                return NotFound();
            }

            return Ok(voyage);
        }

        // PUT: api/Voyages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoyage(int id, Voyage voyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voyage.VoyageId)
            {
                return BadRequest();
            }

            Context.Entry(voyage).State = EntityState.Modified;

            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoyageExists(id))
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

        // POST: api/Voyages
        [ResponseType(typeof(Voyage))]
        public IHttpActionResult PostVoyage(Voyage voyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Context.Voyages.Add(voyage);
            Context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voyage.VoyageId }, voyage);
        }

        // DELETE: api/Voyages/5
        [ResponseType(typeof(Voyage))]
        public IHttpActionResult DeleteVoyage(int id)
        {
            Voyage voyage = Context.Voyages.Find(id);
            if (voyage == null)
            {
                return NotFound();
            }

            Context.Voyages.Remove(voyage);
            Context.SaveChanges();

            return Ok(voyage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoyageExists(int id)
        {
            return Context.Voyages.Count(e => e.VoyageId == id) > 0;
        }
    }
}