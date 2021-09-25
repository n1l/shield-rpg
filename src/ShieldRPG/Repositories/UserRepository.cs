using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Repositories
{
    public class UserRepository
    {
        private Dictionary<(string, string), UserRecord> _userRecords
            = new Dictionary<(string, string), UserRecord>();

        public UserRepository()
        {
            string json = File.ReadAllText(@"Data\Users.json");
            UserRecord[] records = JsonConvert.DeserializeObject<UserRecord[]>(json);
            foreach (UserRecord record in records)
            {
                _userRecords.Add((record.Login, record.Password), record);
            }
        }

        public UserRecord GetUser(string login, string password)
        {
            _userRecords.TryGetValue((login, password), out UserRecord user);
            return user;
        }
    }
}
