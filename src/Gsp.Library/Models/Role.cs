using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gsp.Library.Models
{

    [Table("Roles")]
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }
        public virtual ICollection<RolePosition> RolePositions { get; set; }
    }
}
