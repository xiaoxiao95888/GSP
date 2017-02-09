using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSP.Library.Models
{
    [Table("PositionMenus")]
    public class PositionMenu
    {
        public Guid Id { get; set; }
        public Guid PositionId { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
        public Guid MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }
    }
}
