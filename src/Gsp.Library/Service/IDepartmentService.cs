using System;
using System.Linq;
using Gsp.Library.Models;

namespace Gsp.Library.Service
{
    public interface IDepartmentService : IDisposable
    {
        IQueryable<Department> GetDepartments();
        Department GetDepartment(Guid id);
        void Insert(Department department);
        void Delete(Department department);
        void Update();
    }
}
