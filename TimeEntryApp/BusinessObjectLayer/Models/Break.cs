using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace BusinessObjectLayer.Models
{
    [Table("Break")]
    public class Break
    {
        [Key]
        public int BreakID { get; set; }


        [DataType(DataType.Time)]
        public DateTime BreakIn { get; set; }


        [DataType(DataType.Time)]
        public DateTime BreakOut { get; set; }


        public TimeEntry Entry { get; set; }
    }
}
