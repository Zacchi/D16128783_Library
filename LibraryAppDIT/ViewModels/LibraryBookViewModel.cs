using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryAppDIT.Models;

namespace LibraryAppDIT.ViewModels
{
    public class LibraryBookViewModel
    {
        public Book Book { get; set; }
        public Customer Customers { get; set; }

    }
}