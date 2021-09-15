using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class MrtRequest
    {
        [DisplayName("Код МРТ, КТ, Рентген тела")]
        public string MrtCode { get; set; }
    }
}
