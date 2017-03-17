using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Gsp.Library.Models.Interfaces;

namespace Gsp.Library.Models
{
    [Table("Departments")]
    public class Department: IDtStamped
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Department Parent { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public int? Order { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
