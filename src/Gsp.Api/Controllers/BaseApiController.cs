using System.Web.Http;
using System.Web.Http.Cors;
using Gsp.Api.Models;

namespace Gsp.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseApiController : ApiController
    {
        protected ResponseModel Success()
        {
            return new ResponseModel()
            {
                ErrorCode = 0,
                Message = "Success!",
                Error = false
            };
        }
    }
}
