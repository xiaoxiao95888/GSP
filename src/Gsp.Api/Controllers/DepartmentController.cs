using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gsp.Api.Infrastructure.Exceptions;
using Gsp.Api.Infrastructure.Filters;
using Gsp.Api.Models;
using Gsp.Library.Models;
using Gsp.Library.Service;

namespace Gsp.Api.Controllers
{
    [Token]
    //[RoutePrefix("api/Department")]
    public class DepartmentController : BaseApiController
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
           _departmentService = departmentService;
        }

        public object Post(DepartmentModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ServiceException(100, Resources.Err100InvalidParameters, null);
            }
            if (_departmentService.GetDepartments().Any(n => n.Name == model.Name.Trim()))
            {
                throw new ServiceException(202, Resources.Err202ResourceAlreadyExist, null);
            }
            var department = new Department { Id = Guid.NewGuid(), Name = model.Name.Trim(), Order = model.Order, };
            try
            {
                _departmentService.Insert(department);
            }
            catch (Exception ex)
            {
                throw new ServiceException(500, Resources.Err500CommunicationFailed, ex);
            }
            return Success();
        }

        public IEnumerable<DepartmentModel> Get()
        {
            var models = _departmentService.GetDepartments().Select(n => new DepartmentModel
            {
                Id = n.Id,
                Name = n.Name,
                UpdateTime = n.UpdateTime,
                ParentId = n.ParentId,
                Order = n.Order,
                EmployeeCount =
                    n.Positions.Where(p => !p.IsDeleted)
                        .SelectMany(p => p.EmployeePositions)
                        .Count(p => p.IsDeleted == false && p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now),
                PositionCount = n.Positions.Count(p => !p.IsDeleted),
                IsDeleted = n.IsDeleted

            }).OrderBy(n => n.Order);
            var roots = models.Where(n => n.ParentId == null).ToArray();
            var result = new List<DepartmentModel>();
            SubsDepartment(roots, models.ToArray(), result);
            return result;
        }
        
        public object Put(DepartmentModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ServiceException(100, Resources.Err100InvalidParameters, null);
            }
            var department = _departmentService.GetDepartment(model.Id);
            department.Name = model.Name;
            department.Order = model.Order;
            _departmentService.Update();
            return Success();
        }

        //[Route("DeleteDepartment")]
        public object Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ServiceException(100, Resources.Err100InvalidParameters, null);
            }
            var department = _departmentService.GetDepartment(id);
            if (_departmentService.GetDepartments().Any(n => n.ParentId == id) || department.Positions.Any())
            {
                throw new ServiceException(100, Resources.Err101CascadeDelete, null);
            }
            try
            {
                _departmentService.Delete(department);
                _departmentService.Update();
            }
            catch (Exception ex)
            {
                throw new ServiceException(201, Resources.Err201ResourceNotFound, ex);
            }
            return Success();
        }

        private static void SubsDepartment(IEnumerable<DepartmentModel> roots, DepartmentModel[] all, ICollection<DepartmentModel> childs)
        {
            foreach (var root in roots)
            {
                if (childs.All(n => n.Id != root.Id))
                {
                    childs.Add(root);
                }
                var subs = all.Where(n => n.ParentId == root.Id).ToArray();
                if (subs.Any())
                {
                    SubsDepartment(subs, all, childs);
                }
            }
        }
    }
}
