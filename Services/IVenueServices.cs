using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wizme.Entities;

namespace Wizme.Services
{
    public interface IVenueServices
    {
       IEnumerable<Venue> GetAllVenues();
       Venue GetVenue(Guid id);
       IEnumerable<Space> GetVenueSpaces(Guid Venueid);
       void DeleteVenue(Venue venue);
       void AddVenue(Venue venue);
       bool Save();
    }
}
