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
            string json = File.ReadAllText(@"Data\Records.json");
            DataRecord[] records = JsonConvert.DeserializeObject<DataRecord[]>(json);
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
            => GetDataRecord(code, access, "DnaRequest");

        public (bool success, string message) GetToxinResultFor(string code, int access)
            => GetDataRecord(code, access, "ToxinsRequest");

        public (bool success, string message) GetInfectResultFor(string code, int access)
            => GetDataRecord(code, access, "InfectRequest");

        public (bool success, string message) GetMrtResultFor(string code, int access)
            => GetDataRecord(code, access, "MrtRequest");

        public (bool success, string message) GetSubstancResultFor(string code, int access)
            => GetDataRecord(code, access, "SubstanceRequest");

        public (bool success, string message) GetScanResultFor(string code, int access)
            => GetDataRecord(code, access, "ScanRequest");

        public (bool success, string message) GetSpectrogramResultFor(string code, int access)
            => GetDataRecord(code, access, "SpectrogramRequest");

        public (bool success, string message) GetPersonalDataResultFor(string code, int access)
            => GetDataRecord(code, access, "PersonalDataRequest");

        public (bool success, string message) GetOperationsResultFor(string code, int access)
            => GetDataRecord(code, access, "OperationsRequest");

        public (bool success, string message) GetScienceResultFor(string code, int access)
            => GetDataRecord(code, access, "ScienceRequest");

        private (bool success, string message) GetDataRecord(string code, int access, string requestType)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return (false, $"Не указан запрос. Записей не обнаружено.");
            }
            if (!_dataRecords.ContainsKey(code))
            {
                return (false, $"Записей по коду: '{code}' не обнаружено.");
            }

            foreach (var record in _dataRecords[code])
            {
                if (record.Requests.Contains(requestType))
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
