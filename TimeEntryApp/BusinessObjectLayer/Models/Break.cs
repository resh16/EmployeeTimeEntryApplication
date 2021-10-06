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
        [Column("ID")]
        public int Id { get; set; }
        [Column("EntryID")]
        public int? TimeEntryId { get; set; }
        [Column(TypeName = "datetime")]
        [DataType(DataType.Time)]
        public DateTime? BreakIn { get; set; }
        [Column(TypeName = "datetime")]
        [DataType(DataType.Time)]
        public DateTime? BreakOut { get; set; }

        [ForeignKey(nameof(TimeEntryId))]
        [InverseProperty("Breaks")]
        public virtual TimeEntry Entry { get; set; }
    }
}
