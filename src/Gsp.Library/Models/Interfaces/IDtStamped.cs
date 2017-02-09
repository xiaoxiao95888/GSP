using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSP.Library.Models.Interfaces
{
    public interface IDtStamped
    {
        DateTime UpdateTime { get; set; }
        DateTime CreateTime { get; set; }
        bool IsDeleted { get; set; }
    }
}
