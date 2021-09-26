using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class AssesmentResult
    {
        [JsonProperty("attempts")]
        public int Attempts { get; set; }

        [JsonProperty("words")]
        public List<string> Words { get; set; }
    }
}
