using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gsp.Library.Models;
using Gsp.Library.Service;

namespace Gsp.Service.Service
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(GspDataContext dbContext)
            : base(dbContext)
        {
        }

        public void Delete(Department department)
        {
            DbContext.Departments.Remove(department);
        }

        public Department GetDepartment(Guid id)
        {
            return DbContext.Departments.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<Department> GetDepartments()
        {
            return DbContext.Departments.Where(n => !n.IsDeleted);
        }

        public void Insert(Department department)
        {
            DbContext.Departments.Add(department);
            Update();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
