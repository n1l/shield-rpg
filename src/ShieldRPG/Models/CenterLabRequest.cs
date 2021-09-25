using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class CenterLabRequest
    {
        [DisplayName("Запрос")]
        public string Request { get; set; }

        [DisplayName("Ответ центральной лаборатории")]
        public string Response { get; set; }
    }
}
