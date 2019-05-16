using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wizme.Entities;

namespace Wizme.Services
{
    public class SpaceServices : ISpaceServices
    {
        Context _context;
        public SpaceServices(Context ctx)
        {
            _context = ctx;
        }
        public Space GetSpace(Guid id)
        {
            var space = _context.Spaces.FirstOrDefault(s => s.Id == id);
            return space;
        }
        public IEnumerable<Space> GetAllSpaces()
        {
     //       if (_context.Spaces == null) return null;
            return _context.Spaces.ToList();
        }
        public void AddSpace(Space space)
        {
            if (space != null)
            {
                if (space.Id == null)
                {
                    space.Id = Guid.NewGuid();
                }
                _context.Spaces.Add(space);
            }
        }
        public void DeleteSpace(Space space)
        {
            _context.Spaces.Remove(space);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
