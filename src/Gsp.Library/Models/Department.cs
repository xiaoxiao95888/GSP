using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSP.Library.Models.Interfaces;

namespace GSP.Library.Models
{
    [Table("Departments")]
    public class Department: IDtStamped
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Department Parent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
