using System;
using System.Linq;
using Gsp.Library.Models;

namespace Gsp.Library.Service
{
    public interface IUserService : IDisposable
    {
        IQueryable<User> GetUsers();
        User GetUser(Guid id);
        User GetUser(string token);
        void Insert(User user);
        void Update();
        void Delete(Guid id);
    }
}
