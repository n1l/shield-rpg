using ShieldRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Repositories
{
    public class CenterLabRequestsRepository
    {
        private readonly Dictionary<string, List<CenterLabRequest>> _requestsToCenterLab
            = new Dictionary<string, List<CenterLabRequest>>();

        public List<CenterLabRequest> GetRequests(string userName = null)
        {
            List<CenterLabRequest> requestList = new List<CenterLabRequest>();
            if (string.IsNullOrWhiteSpace(userName))
            {
                foreach (var requests in _requestsToCenterLab)
                {
                    foreach (var request in requests.Value)
                    {
                        requestList.Add(request);
                    }
                }
            }
            else
            {
                foreach (var requests in _requestsToCenterLab)
                {
                    if (requests.Key == userName)
                    {
                        return requests.Value;
                    }
                }
            }

            return requestList;
        }

        public void AddRequest(string userName, CenterLabRequest request)
        {
            if(_requestsToCenterLab.ContainsKey(userName))
            {
                _requestsToCenterLab[userName].Add(request);
            }
            else
            {
                _requestsToCenterLab.Add(userName, new List<CenterLabRequest> { request });
            }
        }
    }
}
