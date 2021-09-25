using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Repositories
{
    public class DataRecord
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public HashSet<string> Requests { get; set; }

        public int Access { get; set; }
    }
}
