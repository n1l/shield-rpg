using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class PersonalDataRequest
    {
        [DisplayName("Код персональных данных")]
        public string PersonalDataCode { get; set; }
    }
}
