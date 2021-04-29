using AdasVetelServer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdasVetelServer.messages
{
    class GetRecordMessage : MessageBase
    {
        public string Route { get; set; }
        public byte[] Record { get; set; }
        public bool IsFirst { get; set; }

        public GetRecordMessage(string route, byte[] record, bool isFirst) : base("RecordRequest")
        {
            Route = route;
            Record = record;
            IsFirst = isFirst;
        }
    }
}
