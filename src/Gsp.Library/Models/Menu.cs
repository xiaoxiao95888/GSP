using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSP.Library.Models
{
    [Table("Menus")]
    public class Menu
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public string Icon { get; set; }
        public string Route { get; set; }
        /// <summary>
        /// 菜单的描述
        /// </summary>
        public string Context { get; set; }
    }
}
