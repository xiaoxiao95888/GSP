using System.Collections.Generic;
using Gsp.Library.Models;

namespace Gsp.Api.Infrastructure.Comparer
{
    public class MenuComparer : IEqualityComparer<Menu>
    {
        public bool Equals(Menu x, Menu y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
            return x.Id == y.Id;

        }
        public int GetHashCode(Menu example)
        {
            return ReferenceEquals(example, null) ? 0 : example.Id.GetHashCode();
        }
    }
}