using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Gsp.Library.Models.Interfaces;

namespace Gsp.Library.Models
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
        public virtual ICollection<RolePosition> RolePositions { get; set; }
        public virtual ICollection<EmployeePosition> EmployeePositions { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
