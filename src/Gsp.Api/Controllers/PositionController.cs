using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gsp.Api.Infrastructure.Filters;
using Gsp.Library.Service;
using Gsp.Api.Models;

namespace Gsp.Api.Controllers
{
    [Token]
    public class PositionController : BaseApiController
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        public IEnumerable<PositionModel> Get()
        {
            var models = _positionService.GetPositions().Select(n => new PositionModel
            {
                Code = n.Code,
                DepartmentId = n.DepartmentId,
                DepartmentName = n.Department.Name,
                Id = n.Id,
                Name = n.Name,
                UpdateTime = n.UpdateTime,
                CurrentEmployeeId =
                    n.EmployeePositions.Where(
                        p =>
                            p.IsDeleted == false && p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now &&
                            p.Employee.IsDeleted == false).Select(p => p.Employee.Id).FirstOrDefault(),
                CurrentEmployeeName =
                    n.EmployeePositions.Where(
                        p =>
                            p.IsDeleted == false && p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now &&
                            p.Employee.IsDeleted == false).Select(p => p.Employee.Name).FirstOrDefault(),
            });
            return models;
        }
    }
}
