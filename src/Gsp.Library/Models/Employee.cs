using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Gsp.Library.Models.Interfaces;

namespace Gsp.Library.Models
{
    [Table("Employees")]
    public class Employee : IDtStamped
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Birth { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string HeadImgUrl { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string JobNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string EducationalLevel { get; set; }
        /// <summary>
        /// 户籍地
        /// </summary>
        public Guid? NativePlace { get; set; }
        [ForeignKey("NativePlace")]
        public virtual Location NativePlaceLocation { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string CardNo { get; set; }
        [Column(TypeName = "date")]
        public DateTime JoinedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LeaveDate { get; set; }
        public virtual ICollection<EmployeePosition> EmployeePositions { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
