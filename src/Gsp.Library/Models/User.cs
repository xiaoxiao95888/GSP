using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gsp.Library.Models
{
    [Table("Users")]
    public class User
    {
        public Guid Id { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
        public Guid EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}
