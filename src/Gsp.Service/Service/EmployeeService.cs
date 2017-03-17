using System;
using System.Linq;
using Gsp.Library.Models;
using Gsp.Library.Service;

namespace Gsp.Service.Service
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(GspDataContext dbContext)
            : base(dbContext)
        {
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(Guid id)
        {
            return DbContext.Employees.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<Employee> GetEmployees()
        {
            return DbContext.Employees.Where(n => !n.IsDeleted);
        }

        public void Insert(Employee employee)
        {
            DbContext.Employees.Add(employee);
            Update();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
