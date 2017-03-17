using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Gsp.Api.Infrastructure.Exceptions;
using Gsp.Api.Models;
using Newtonsoft.Json;

namespace Gsp.Api.Infrastructure.Filters
{
    public class TokenAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            //#region 测试环境模拟已登录
            //using (IUserService service = new UserService(new GspDataContext()))
            //{

            //    var user = service.GetUsers().FirstOrDefault(n => n.Employee.Name == "Judy");
            //    var identity =
            //       AuthenticationService.CreateIdentity(
            //           new UserModel { Id = user.Employee.Id, Name = user.Employee.Name, Token = user.Token },
            //           DefaultAuthenticationTypes.ApplicationCookie);



            //    HttpContext.Current.GetOwinContext()
            //        .Authentication.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);
            //    token = user.Token;
            //}
            //#endregion
            var valid = true;
            try
            {
                var token = filterContext.Request.Headers.Authorization.ToString();
                var jwt = new Jwt
                {
                    Header = JsonConvert.DeserializeObject<Header>(token.Split('.')[0].Base64Decryption()),
                    Claims = JsonConvert.DeserializeObject<Claims>(token.Split('.')[1].Base64Decryption()),
                    Signature = token.Split('.')[2]
                };
               
                var content =
                    $"{JsonConvert.SerializeObject(jwt.Header).Base64Encryption()}.{JsonConvert.SerializeObject(jwt.Claims).Base64Encryption()}";
                var signature = ($"{content}.{ConfigurationManager.AppSettings["AppSecret"]}").Sha256Encryption();
                if (jwt.Signature == signature && (DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds < jwt.Claims.Exp)
                {
                    //将用户添加到http的上下文中
                    var identity = new CustomIdentity(new UserModel { Token = jwt.Claims.UserToken });
                    var principal = new CustomPrincipal(identity);
                    HttpContext.Current.User = principal;
                }
                else
                {
                    valid = false;
                }

            }
            catch (Exception)
            {
                valid = false;
            }

            if (!valid)
            {
                var errorResponse = filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized);//InternalServerError
                filterContext.Response = errorResponse;
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}