using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryAppDIT.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength (255)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        [Display(Name = "Birthday")]
        public DateTime DOB { get; set; }
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
    }
}