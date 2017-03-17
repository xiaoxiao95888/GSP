using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsp.Api.Models
{
    public class MenuModel
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        public string RouteName { get; set; }
        public string Title { get; set; }
        public int? Order { get; set; }
      
    }
}