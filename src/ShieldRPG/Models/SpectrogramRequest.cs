using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class SpectrogramRequest
    {
        [DisplayName("Код спектрогафа (химический состав)")]
        public string SpectrogramCode { get; set; }
    }
}
