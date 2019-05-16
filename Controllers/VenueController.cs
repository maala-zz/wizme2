using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wizme.Services;
using Wizme.Models;
using AutoMapper;
using Wizme.Entities;

namespace Wizme.Controllers
{
    [Route("api/venues")]
    public class VenueController : Controller
    {
        private IVenueServices _venueservices;

        public VenueController(IVenueServices serv)
        {
            _venueservices = serv;
        }
        public IActionResult Index()
        {
            var venues = _venueservices.GetAllVenues();
            var venuesDto = Mapper.Map<IEnumerable<VenueDto>>(venues);
            return View(venuesDto);
        }
        [HttpGet()]
        public IActionResult GetAllVenues()
        {
            var venues = _venueservices.GetAllVenues();
            var venuesDto = Mapper.Map<IEnumerable<VenueDto>>(venues);
            return new JsonResult(venuesDto);
        }
        [HttpGet("{id}", Name ="GetVenue")]
        public IActionResult GetVenue(Guid id)
        {
            var venue = _venueservices.GetVenue(id);
            var venueDto = Mapper.Map<VenueDto>(venue);
            return new JsonResult(venueDto);
        }
        [HttpGet("{id}/spaces")]
        public IActionResult GetVenueSpaces(Guid id)
        {
            var spaces = _venueservices.GetVenueSpaces(id);
            var spacesDto = Mapper.Map<IEnumerable<SpaceDto>>(spaces);
            return new JsonResult(spacesDto);
        }
        [HttpPost()]
        public IActionResult AddVenue([FromBody]Venue venue)
        {
            if (venue == null)
                return BadRequest();
            if (venue.Id == null) venue.Id = Guid.NewGuid();
            _venueservices.AddVenue(venue);
            if (!_venueservices.Save())
                throw new Exception("something went wrong, try again later");
            return CreatedAtAction("GetVenue", new { id = venue.Id }, venue);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVenue(Guid id)
        {
            var venue = _venueservices.GetVenue(id);
            if (venue == null)
                return NotFound();
            _venueservices.DeleteVenue(venue);
            if (!_venueservices.Save())
                throw new Exception("something went wrong, try again later");
            return NoContent();
        }
    }
}