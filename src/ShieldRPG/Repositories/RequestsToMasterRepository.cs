using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Repositories
{
    public class RequestsToMasterRepository
    {
        private readonly Dictionary<string, (string request, string response)> _requestsToMaster
            = new Dictionary<string, (string request, string response)>();

        public List<(string request, string response)> GetRequests(string userName = null)
        {
            List<(string request, string response)> filteredRequests = new List<(string request, string response)>();
            foreach (var request in _requestsToMaster)
            {
                if (userName == null || request.Key == userName)
                {
                    filteredRequests.Add(request.Value);
                }
            }

            return filteredRequests;
        }
    }
}
