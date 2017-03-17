using System;
using System.Linq;
using Gsp.Library.Models;

namespace Gsp.Library.Service
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
