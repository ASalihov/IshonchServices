using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace NewTests
{

    public class Context : DbContext
    {
        public Context()
            : base("DbConnection")
        {
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Company> Companies { get; set; }
    }

    public class Guest
    {
        public int GuestID { get; set; }
        public int? CompanyID { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
    }

    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public ObservableCollection<Guest> Guests { get; set; }
    }

}
