using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Repositories
{
    public class UserRecord
    {
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Access { get; set; }
        public int HackerRank { get; set; }
        public string[] Roles { get; set; }
    }
}