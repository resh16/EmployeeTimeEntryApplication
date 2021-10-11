using BusinessObjectLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.ViewModel
{
    public class TotalBreak
    {
        public int BreakID { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan BreakIn { get; set; }


        [DataType(DataType.Time)]
        public TimeSpan BreakOut { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan TotalTime { get; set; }

        public TimeEntry Entry { get; set; }
    }
}
