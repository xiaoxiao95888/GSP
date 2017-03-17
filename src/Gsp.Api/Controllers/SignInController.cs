using System;
using System.Configuration;
using System.Linq;
using Gsp.Api.Infrastructure.Exceptions;
using Gsp.Api.Models;
using Gsp.Library.Service;
using Newtonsoft.Json;

namespace Gsp.Api.Controllers
{
    public class SignInController : BaseApiController
    {
        private readonly IUserService _userService;

        public SignInController(IUserService userService)
        {
            _userService = userService;
        }


        public object Post(LoginModel model)
        {
            var user =
                _userService
                    .GetUsers()
                    .FirstOrDefault(n => n.Employee.Email == model.AppId || n.Employee.Phone == model.AppId || n.Token == model.AppId);
            if (user != null && Math.Abs(((int)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds) - model.TimeStamp) <= 30)
            {
                var signature = (model.Random + model.TimeStamp + user.PasswordHash.ToLower()).Sha256Encryption().ToUpper();
                if (model.Signature.ToUpper() == signature)
                {
                    var authenticationTimeoutDays = Convert.ToInt32(ConfigurationManager.AppSettings["AuthenticationTimeoutDays"]);
                    var jwt = new Jwt
                    {
                        Header = new Header
                        {
                            Typ = "JWT",
                            Alg = "HS256"
                        },
                        Claims = new Claims
                        {
                            Exp = (DateTime.Now.AddDays(authenticationTimeoutDays) - new DateTime(1970, 1, 1)).TotalSeconds,
                            EmployeeName = user.Employee.Name,
                            UserToken = Guid.NewGuid().ToString()
                        }
                    };
                    var content =
                        $"{JsonConvert.SerializeObject(jwt.Header).Base64Encryption()}.{JsonConvert.SerializeObject(jwt.Claims).Base64Encryption()}";
                    jwt.Signature = ($"{content}.{ConfigurationManager.AppSettings["AppSecret"]}").Sha256Encryption();
                    //base64url_encode(Header) + '.' + base64url_encode(Claims) + '.' + base64url_encode(Signature)
                    var token = $"{content}.{jwt.Signature}";
                    user.Token = jwt.Claims.UserToken;
                    _userService.Update();
                    return token;
                }
            }
            throw new ServiceException(2000, Resources.Err2000LoginFailed, null);
        }



        //创建随机字符串  
        private string CreateNonceStr()
        {
            const int length = 16;
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var str = string.Empty;
            var rad = new Random();
            for (var i = 0; i < length; i++)
            {
                str += chars.Substring(rad.Next(0, chars.Length - 1), 1);
            }
            return str;
        }
    }
}
