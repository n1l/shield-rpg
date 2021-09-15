using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class DnaRequest
    {
        [DisplayName("Код образца крови")]
        public string BloodCode { get; set; }
    }
}
