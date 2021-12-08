using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class LoginsContext :DbContext
    {
        public DbSet<Logins> Logins { get; set; }
        public DbSet<Password> Password { get; set; }
    }
}
