using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wizme.Entities;

namespace Wizme.Services
{
    public class VenueServices : IVenueServices
    {
        Context _context;
        public VenueServices(Context context)
        {
            _context = context;
        }
        public IEnumerable<Venue> GetAllVenues()
        {
            if (_context.Venues == null) return null;
            return _context.Venues.ToList();
        }
        public IEnumerable<Space> GetVenueSpaces(Guid Venueid)
        {
            if (_context.Spaces.Where(s => s.VenueId == Venueid) == null)
                return null;
            return _context.Spaces.Where(s => s.VenueId == Venueid).ToList();
        }

        public Venue GetVenue(Guid id)
        {
            return _context.Venues.FirstOrDefault(v => v.Id == id);
        }
        public void AddVenue(Venue venue)
        {
            _context.Venues.Add(venue);
        }

        public void DeleteVenue(Venue venue)
        {
            _context.Venues.Remove(venue);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
