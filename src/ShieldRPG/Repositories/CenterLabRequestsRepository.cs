using ShieldRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Repositories
{
    public class CenterLabRequestsRepository
    {
        private readonly Dictionary<Guid, CenterLabRequest> _requestsToCenterLab
            = new Dictionary<Guid, CenterLabRequest>();

        public List<CenterLabRequest> GetRequests(string userName = null)
        {
            List<CenterLabRequest> requestList = new List<CenterLabRequest>();
            if (string.IsNullOrWhiteSpace(userName))
            {
                foreach (var requests in _requestsToCenterLab)
                {
                    requestList.Add(requests.Value);
                }
            }
            else
            {
                foreach (var requests in _requestsToCenterLab)
                {
                    if (requests.Value.UserName == userName)
                    {
                        requestList.Add(requests.Value);
                    }
                }
            }

            return requestList;
        }

        public CenterLabRequest GetRequestById(Guid id)
        {
            _requestsToCenterLab.TryGetValue(id, out CenterLabRequest request);
            return request;
        }

        public void AddRequest(CenterLabRequest request)
        {
            if (!_requestsToCenterLab.ContainsKey(request.Id))
            {
                _requestsToCenterLab.Add(request.Id, request);
            }
            else
            {
                _requestsToCenterLab[request.Id] = request;
            }
        }
    }
}
