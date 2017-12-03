using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryAppDIT.Models
{
    public class Book
    {
        [Key]
        public int ISBN { get; set; }

        public string Title { get; set; }

        //public string Genre { get; set; }
        public GenreType GenreType { get; set; }
        
        public int GenreTypeId { get; set; }

        public string Author { get; set; }

        [Display(Name = "Published Year")]
        public string publishedYear {get; set;}
    }
}