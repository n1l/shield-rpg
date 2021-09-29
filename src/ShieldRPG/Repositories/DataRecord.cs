using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Repositories
{
    public class DataRecord
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Text { get; set; }

        private string _requestType;
        public string RequestType
        {
            get { return _requestType; }
            set { _requestType = value?.Trim().ToLower(); }
        }

        public int Access { get; set; }
    }
}
