using System;
using System.ComponentModel.DataAnnotations.Schema;
using Gsp.Library.Models.Interfaces;

namespace Gsp.Library.Models
{
    [Table("EmployeePositions")]
    public class EmployeePosition : IDtStamped
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid PositionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
