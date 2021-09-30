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

    public class DataRecordView
    {
        public DataRecordView(DataRecord record)
        {
            if (record != null)
            {
                Id = record.Id;
                Code = record.Code;
                Text = record.Text;
                Access = record.Access;

                if (record.RequestType == "prd")
                {
                    RequestType =  "Личное дело";
                }
                else if (record.RequestType == "ops")
                {
                    RequestType = "Операция";

                }
                else if (record.RequestType == "sci")
                {
                    RequestType = "Научно-исследовательские материалы";
                }
                else if (record.RequestType == "medcart")
                {
                    RequestType = "Мед. карта";
                }
                else
                {
                    RequestType = record.RequestType;
                }
            }
        }

        public Guid Id { get; }

        public string Code { get; }

        public string Text { get; }

        public string RequestType { get; }

        public int Access { get; }
    }
}
