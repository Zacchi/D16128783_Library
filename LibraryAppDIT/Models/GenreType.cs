using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryAppDIT.Models
{
    public class GenreType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}