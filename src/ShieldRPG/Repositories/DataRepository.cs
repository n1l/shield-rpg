using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Repositories
{
    public class DataRepository
    {
        private Dictionary<string, List<DataRecord>> _dataRecords = new Dictionary<string, List<DataRecord>>();

        public DataRepository()
        {
            string josn = File.ReadAllText(@"Data\Records.json");
            DataRecord[] records = JsonConvert.DeserializeObject<DataRecord[]>(josn);
            foreach (DataRecord record in records)
            {
                if(_dataRecords.ContainsKey(record.Id))
                {
                    _dataRecords[record.Id].Add(record);
                }
                else
                {
                    _dataRecords.Add(record.Id, new List<DataRecord> { record });
                }
            }
        }
        public (bool success, string message) GetDnaResultFor(string code, int access)
        {
            if (!_dataRecords.ContainsKey(code))
            {
                return (false, $"Записей по коду: '{code}' не обнаружено");
            }
            
            foreach (var record in _dataRecords[code])
            {
                if (record.Requests.Contains("DnaRequest"))
                {
                    if (record.Access > access)
                    {
                        return (false, $"Недостаточный уровень доступа. Запись '{code}'.");
                    }
                    
                    return (true, record.Text);
                }
            }

            return (false, $"Записей по коду: '{code}' не обнаружено");
        }
    }
}
