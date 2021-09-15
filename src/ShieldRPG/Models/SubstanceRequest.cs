using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class SubstanceRequest
    {
        [DisplayName("Код анализа структуры вещества")]
        public string SubstanceCode { get; set; }
    }
}
