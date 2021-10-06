using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Entries = new List<TimeEntry>();
        }

        public IList<TimeEntry> Entries { get; set; }
    }
}