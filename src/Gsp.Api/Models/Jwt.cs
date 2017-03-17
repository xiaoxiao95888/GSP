using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsp.Api.Models
{
    public class Jwt
    {
        public Header Header { get; set; }
        public Claims Claims { get; set; }
        public string Signature { get; set; }
    }

    public class Header
    {
        /// <summary>
        ///  必需,token 类型，JWT 表示是 JSON Web Token
        /// </summary>
        public string Typ { get; set; }
        /// <summary>
        /// 必需,token 所使用的签名算法，可用的值在https://tools.ietf.org/html/rfc7518#section-3.1有规定。
        /// </summary>
        public string Alg { get; set; }
    }

    public class Claims
    {
        /// <summary>
        /// 过期时间
        /// </summary>
        public double Exp { get; set; }
        /// <summary>
        /// 用户的唯一标示,相当于UserId，但每次用户登录后都会变化
        /// </summary>
        public string UserToken { get; set; }
        public string EmployeeName { get; set; }
    }
}