using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Logins
    {
        public Logins()
        {
            Passwords = new List<Password>();
        }
        public int LoginId { get; set; }
        public string Name { get; set; }

        public virtual List<Password> Passwords { get; set; }
    }
}
