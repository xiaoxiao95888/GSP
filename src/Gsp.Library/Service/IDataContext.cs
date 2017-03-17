using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Gsp.Library.Models;

namespace Gsp.Library.Service
{
    public interface IDataContext : IObjectContextAdapter, IDisposable
    {
        IDbSet<Location> Locations { get; set; }
        IDbSet<Employee> Employees { get; set; }
        IDbSet<User> Users { get; set; }
        IDbSet<Role> Role { get; set; }
        IDbSet<Position> Positions { get; set; }
        IDbSet<Department> Departments { get; set; }
        int SaveChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
