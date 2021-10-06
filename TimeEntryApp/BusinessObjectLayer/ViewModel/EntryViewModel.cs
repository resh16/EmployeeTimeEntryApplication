using BusinessObjectLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.ViewModel
{
    public class EntryView_Model
    {

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date is required")]
        public DateTime? Date { get; set; }
        [Column(TypeName = "datetime")]

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "InTime is required")]
        public DateTime? InTime { get; set; }
        [Column(TypeName = "datetime")]

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "OutTime is required")]
        public DateTime? OutTime { get; set; }

        public virtual List<Break> BreakList { get; set; } = new List<Break>();

    }
}
