using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsp.Api.Models
{
    public class LoginModel
    {
        public string AppId { get; set; }
        public string Random { get; set; }
        public int TimeStamp { get; set; }
        /// <summary>
        /// sha1(random+timestamp+password)
        /// </summary>
        public string Signature { get; set; }
    }
}