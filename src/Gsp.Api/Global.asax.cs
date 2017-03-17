using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Gsp.Api.Infrastructure.Filters;

namespace Gsp.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Handle all exception
            GlobalConfiguration.Configuration.Filters.Add(new CustomExceptionFilter());
        }
    }
}
