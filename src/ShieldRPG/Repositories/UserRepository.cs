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
        private static readonly object _lock = new object();

        private Dictionary<string, UserRecord> _userRecords
            = new Dictionary<string, UserRecord>();

        public UserRepository()
        {
            string json = File.ReadAllText(@"Data\Users.json");
            UserRecord[] records = JsonConvert.DeserializeObject<UserRecord[]>(json);
            foreach (UserRecord record in records)
            {
                _userRecords.Add(record.Login, record);
            }
        }

        public UserRecord GetUser(string login, string password)
        {
            bool found = _userRecords.TryGetValue(login, out UserRecord user);
            if (found && password == user.Password)
            {
                return user;
            }

            return null;
        }

        public List<UserRecord> GetUsers()
        {
            return _userRecords.Values.OrderBy(user => user.UserName).ToList();
        }

        public UserRecord GetUserDataByLogin(string login)
        {
            _userRecords.TryGetValue(login, out UserRecord user);
            return user;
        }

        public void UpdateUserData(UserRecord userRecord)
        {
            if(!_userRecords.ContainsKey(userRecord.Login))
            {
                return;
            }

            var content = JsonConvert.SerializeObject(_userRecords.Values.ToArray());
            lock (_lock)
            {
                File.WriteAllText(@"Data\Users.json", content);
            }

            _userRecords[userRecord.Login] = userRecord;
        }
    }
}
