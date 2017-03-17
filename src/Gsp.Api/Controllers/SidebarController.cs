using System;
using System.Linq;
using System.Web;
using Gsp.Api.Infrastructure.Comparer;
using Gsp.Api.Infrastructure.Exceptions;
using Gsp.Api.Infrastructure.Filters;
using Gsp.Api.Models;
using Gsp.Library.Service;

namespace Gsp.Api.Controllers
{
    [Token]
    public class SidebarController : BaseApiController
    {
        private readonly IUserService _userService;

        public SidebarController(IUserService userService)
        {
            _userService = userService;
        }

        public object Get()
        {
            var userToken = HttpContext.Current.User.Identity.GetUser().Token;
            var employee = _userService.GetUser(userToken).Employee;
            var positions =
                employee.EmployeePositions.Where(
                    n => n.IsDeleted == false && n.StartDate <= DateTime.Now && n.EndDate >= DateTime.Now)
                    .Select(n => n.Position);
            var roles = positions.SelectMany(p => p.RolePositions.Select(n => n.Role));
            var menus = roles.SelectMany(n => n.RoleMenus.Select(p => p.Menu)).Distinct(new MenuComparer()).ToArray();
            var menumodels =
                menus.OrderBy(n => n.Order)
                    .Select(
                        p =>
                            new MenuModel
                            {
                                Id = p.Id,
                                Title = p.Title,
                                RouteName = p.ParentId == null
                                    ? p.RouteName
                                    : menus.Where(n => n.Id == p.ParentId)
                                        .Select(n => n.RouteName + "." + p.RouteName)
                                        .FirstOrDefault(),
                                Order=p.Order
                            })
                    .ToArray();
            return menumodels;
        }
    }
}
