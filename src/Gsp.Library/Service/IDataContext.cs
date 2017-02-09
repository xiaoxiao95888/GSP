using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GSP.Library.Models;

namespace GSP.Library.Service
{
    public interface IDataContext : IObjectContextAdapter, IDisposable
    {
        IDbSet<Location> Locations { get; set; }
        IDbSet<Employee> Employees { get; set; }
        IDbSet<User> Users { get; set; }
        int SaveChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
