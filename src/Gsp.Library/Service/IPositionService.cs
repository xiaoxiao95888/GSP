using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSP.Library.Models;

namespace GSP.Library.Service
{
    public interface IPositionService : IDisposable
    {
        IQueryable<Position> GetPositions();
        Position GetPosition(Guid id);
        void Insert(Position position);
        void Update();
    }
}
