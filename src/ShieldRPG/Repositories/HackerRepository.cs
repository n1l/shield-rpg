using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Repositories
{
    public class HackerRepository
    {
        private readonly Dictionary<string, DateTimeOffset> _lastAttempts = new Dictionary<string, DateTimeOffset>();
        private readonly Dictionary<string, int> _successes = new Dictionary<string, int>();
        private readonly Dictionary<int, int> _hackerRankAttempts = new Dictionary<int, int>
        {
            { 1, 5 },
            { 2, 7 },
            { 3, 9 }
        };

        public bool CanHack(string login)
         => !string.IsNullOrWhiteSpace(login)
                && (!_lastAttempts.ContainsKey(login) || DateTimeOffset.UtcNow.AddHours(-1) > _lastAttempts[login]);

        public int GetAttempts(int hackerRank)
        {
            if (hackerRank > 3) { return 9; }
            if (hackerRank < 1) { return 0; }

            return _hackerRankAttempts[hackerRank];
        }

        public void UpdateAttempt(string login, bool success)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                return;
            }

            if (!success)
            {
                if (_lastAttempts.ContainsKey(login))
                {
                    _lastAttempts[login] = DateTimeOffset.UtcNow;
                }
                else
                {
                    _lastAttempts.Add(login, DateTimeOffset.UtcNow);
                }

                return;
            }

            if (_successes.ContainsKey(login))
            {
                _successes[login]++;
            }
            else
            {
                _successes.Add(login, 1);
            }

            if (_successes[login] > 1)
            {
                if(_lastAttempts.ContainsKey(login))
                {
                    _lastAttempts[login] = DateTimeOffset.UtcNow;
                }
                else
                {
                    _lastAttempts.Add(login, DateTimeOffset.UtcNow);
                }
            }
        }
    }
}
