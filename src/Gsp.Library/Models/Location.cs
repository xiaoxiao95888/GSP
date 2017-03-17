using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gsp.Library.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public Guid? ParentId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
