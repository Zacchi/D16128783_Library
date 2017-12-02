using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryAppDIT.Models;

namespace LibraryAppDIT.ViewModels
{
    public class LibraryViewModel
    {
        public Book Book { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<GenreType> GenreTypes { get; set; }
    }
}