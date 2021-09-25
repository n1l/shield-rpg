using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class ScanRequest
    {
        [DisplayName("Код сканирования обьекта")]
        public string ScanCode { get; set; }
    }
}
