using System;
using System.Linq;
using Gsp.Library.Models;

namespace Gsp.Library.Service
{
    public interface IEmployeeService : IDisposable
    {
        IQueryable<Employee> GetEmployees();
        Employee GetEmployee(Guid id);
        void Insert(Employee employee);
        void Update();
        void Delete(Guid id);
    }
}
