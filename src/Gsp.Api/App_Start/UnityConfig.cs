using Microsoft.Practices.Unity;
using System.Web.Http;
using Gsp.Library.Service;
using Gsp.Service.Service;
using Unity.WebApi;

namespace Gsp.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IPositionService, PositionService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}