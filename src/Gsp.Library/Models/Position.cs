using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GSP.Library.Models.Interfaces;

namespace GSP.Library.Models
{
    [Table("Positions")]
    public class Position : IDtStamped
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<PositionMenu> Menus { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
