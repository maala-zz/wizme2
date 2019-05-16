using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wizme.Entities;

namespace Wizme.Services
{
    public interface ISpaceServices
    {
        Space GetSpace(Guid id);
        IEnumerable<Space> GetAllSpaces();
        void AddSpace(Space space);
        void DeleteSpace(Space space);
        bool Save();
    }
}
