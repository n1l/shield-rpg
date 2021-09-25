using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class OperationsRequest
    {
        [DisplayName("Код операции")]
        public string OperationsCode { get; set; }
    }
}
