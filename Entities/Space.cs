using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wizme.Entities
{
    public class Space
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Shape { get; set; }
        public Double Price { get; set; }
        public Guid VenueId { get;set; }
        public Venue Venue { get; set; }
    }
}
