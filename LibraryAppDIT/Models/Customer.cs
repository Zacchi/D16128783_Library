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
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public int PhoneNumber { get; set; }
    }
}