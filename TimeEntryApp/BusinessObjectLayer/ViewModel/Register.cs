using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.Models
{
    public class Register
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirm password does not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public bool Admin { get; set; }
    }
}
