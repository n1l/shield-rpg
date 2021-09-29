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
        private Dictionary<Guid, DataRecord> _dataRecords = new Dictionary<Guid, DataRecord>();

        public DataRepository()
        {
            string json = File.ReadAllText(@"Data\Records.json");
            DataRecord[] records = JsonConvert.DeserializeObject<DataRecord[]>(json);
            foreach (DataRecord record in records)
            {
                record.Id = Guid.NewGuid();
                _dataRecords.Add(record.Id, record);
            }
        }

        public List<DataRecord> GetRecordList(params string[] requestTypes)
        {
            HashSet<string> types = new HashSet<string>(requestTypes);
            if (types.Count == 0)
            {
                return _dataRecords.Values.OrderBy(record => record.Code).ToList();
            }

            return _dataRecords.Values.Where(record => types.Contains(record.RequestType)).OrderBy(record => record.Code).ToList();
        }

        public DataRecord GetRecordById(Guid id)
        {
            _dataRecords.TryGetValue(id, out DataRecord dataRecord);

            return dataRecord;
        }

        public void UpdateRecord(DataRecord record)
        {
            if (_dataRecords.ContainsKey(record.Id))
            {
                _dataRecords[record.Id] = record;
            }
            else
            {
                _dataRecords.Add(record.Id, record);
            }
        }

        public (bool success, string message) GetDnaResultFor(string code, int access)
            => GetDataRecord(code, access, "dna");

        public (bool success, string message) GetMedcartResultFor(string code, int access)
            => GetDataRecord(code, access, "medcart");

        public (bool success, string message) GetToxinResultFor(string code, int access)
            => GetDataRecord(code, access, "tox");

        public (bool success, string message) GetInfectResultFor(string code, int access)
            => GetDataRecord(code, access, "inft");

        public (bool success, string message) GetMrtResultFor(string code, int access)
            => GetDataRecord(code, access, "mrt");

        public (bool success, string message) GetSubstancResultFor(string code, int access)
            => GetDataRecord(code, access, "sbst");

        public (bool success, string message) GetScanResultFor(string code, int access)
            => GetDataRecord(code, access, "scan");

        public (bool success, string message) GetSpectrogramResultFor(string code, int access)
            => GetDataRecord(code, access, "spgm");

        public (bool success, string message) GetPersonalDataResultFor(string code, int access)
            => GetDataRecord(code, access, "prd");

        public (bool success, string message) GetOperationsResultFor(string code, int access)
            => GetDataRecord(code, access, "ops");

        public (bool success, string message) GetScienceResultFor(string code, int access)
            => GetDataRecord(code, access, "sci");

        private (bool success, string message) GetDataRecord(string code, int access, string requestType)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return (false, $"Не указан запрос. Записей не обнаружено.");
            }

            foreach (var record in _dataRecords.Values)
            {
                if (record.Code == code && record.RequestType == requestType)
                {
                    if (record.Access > access)
                    {
                        return (false, $"Недостаточный уровень доступа. Запись '{code}'.");
                    }

                    return (true, record.Text);
                }
            }

            return (false, $"Записей по коду: '{code}' не обнаружено.");
        }
    }
}
