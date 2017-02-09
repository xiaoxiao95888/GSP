using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSP.Library.Models;

namespace GSP.Library.Service
{
    public interface IUserService : IDisposable
    {
        IQueryable<User> GetUsers();
        User GetUser(Guid id);
        void Insert(User user);
        void Update();
        void Delete(Guid id);
    }
}
