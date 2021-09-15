using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class InfectRequest
    {
        [DisplayName("Код анализа на наличие инфекций")]
        public string InfectCode { get; set; }
    }
}
