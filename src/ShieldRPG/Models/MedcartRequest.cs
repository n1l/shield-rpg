using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class MedcartRequest
    {
        [DisplayName("Код мед. карты")]
        public string MedcartCode { get; set; }
    }
}
