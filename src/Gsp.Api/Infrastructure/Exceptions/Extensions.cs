using System;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using Gsp.Api.Models;

namespace Gsp.Api.Infrastructure.Exceptions
{
    public static class Extensions
    {
        public static string Sha256Encryption(this string context)
        {
            var sha256Data = Encoding.Default.GetBytes(context);
            var sha256 = new SHA256Managed();
            var result = sha256.ComputeHash(sha256Data);
            return BitConverter.ToString(result).Replace("-", "");
        }
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="context">需要加密的字符串</param>
        /// <returns>返回加密的结果</returns>
        public static string Base64Encryption(this string context)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(context));
        }
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string Base64Decryption(this string context)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(context));
        }
        public static UserModel GetUser(this IIdentity identity)
        {
            var customIdentity = (CustomIdentity)identity;
            return customIdentity.User;
        }
    }
}