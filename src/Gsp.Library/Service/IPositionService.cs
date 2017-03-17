using System;
using System.Linq;
using Gsp.Library.Models;

namespace Gsp.Library.Service
{
    public interface IPositionService : IDisposable
    {
        IQueryable<Position> GetPositions();
        Position GetPosition(Guid id);
        void Insert(Position position);
        void Update();
    }
}
