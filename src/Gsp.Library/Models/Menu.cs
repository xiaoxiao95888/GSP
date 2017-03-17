using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gsp.Library.Models
{
    [Table("Menus")]
    public class Menu
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        public string RouteName { get; set; }
        public Guid? ParentId { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// 菜单的描述
        /// </summary>
        public string Context { get; set; }
        public int? Order { get; set; }
        public virtual ICollection<RoleMenu> RoleMenus { get; set; } 
    }
}
