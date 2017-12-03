using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryAppDIT.Models;
using System.Data.SqlClient;

namespace LibraryAppDIT.Controllers.Api
{
    public class UsersListController : ApiController
    {
        private ApplicationDbContext _dbcontext;

        public UsersListController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        public List<UsersListFromDB> GetUsersList()
        {
            var results = _dbcontext
               .Users
               .Select(z => new UsersListFromDB
               {
                   Name = z.Name,
                   Address = z.Address,
                   DOB = z.DOB,
                   Email = z.Email,
                   Phone = z.Phone
               }).ToList();

            return results;

        }

        public class UsersListFromDB
        {
            public string Name;
            public string Address;
            public DateTime DOB;
            public string Email;
            public int Phone;

            internal object ToList()
            {
                throw new NotImplementedException();
            }
        }

    }
}
