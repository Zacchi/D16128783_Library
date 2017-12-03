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

        [Required]
        public string Title { get; set; }

        public GenreType GenreType { get; set; }
        
        public int GenreTypeId { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Published Year")]
        public string publishedYear {get; set;}
    }
}