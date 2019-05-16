using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Wizme.Entities
{
    public class Venue
    {
        public Guid Id { set; get; }
        public String Img { set; get; }
        public String Descreption { set; get; }
        public String Chain { get; set; }
        public String Brand { get; set; }
        public ICollection<Space> Spaces { get; set; }
    }
}
