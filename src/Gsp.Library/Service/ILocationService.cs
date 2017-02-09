using GSP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSP.Library.Service
{
    public interface ILocationService : IDisposable
    {
        IQueryable<Location> GetlLocations();
        Location GetLocation(Guid id);
        void Insert(Location location);
        void Update();
        void Delete(Guid id);
    }
}
