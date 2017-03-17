using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Gsp.Api.Infrastructure.Exceptions;
using Gsp.Api.Models;

namespace Gsp.Api.Infrastructure.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context == null || context.Exception == null)
            {
                return;
            }

            var response = new ResponseModel {Error = true};

            var serviceException = context.Exception as ServiceException;
            if (serviceException != null)
            {
                var exception = serviceException;
                response.Message = serviceException.Message;
                response.ErrorCode = exception.ErrorCode;

            }
            else
            {
                //response.DebugMessage = context.Exception.Message;
                response.ErrorCode = 500;
            }

            //this.GetLogger().Error(context.Exception);
            //var statusCode = HttpStatusCode.InternalServerError;
            var statusCode = HttpStatusCode.BadRequest;
           
            if (response.ErrorCode == 2000)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            
            var errorResponse = context.Request.CreateResponse(statusCode, response);//InternalServerError
            context.Response = errorResponse;

            base.OnException(context);
        }

    }
}