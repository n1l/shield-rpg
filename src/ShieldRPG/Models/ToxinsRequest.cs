using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class ToxinsRequest
    {
        [DisplayName("Код анализа на токсины")]
        public string ToxinsCode { get; set; }
    }
}
