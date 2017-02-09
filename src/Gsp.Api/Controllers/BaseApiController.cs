using System.Web.Http;
using System.Web.Http.Cors;

namespace Gsp.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseApiController : ApiController
    {
    }
}
