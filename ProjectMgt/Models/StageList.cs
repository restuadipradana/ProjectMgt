using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMgt.Models
{
    public class StageList
    {
        [BsonId]
        public Guid id { get; set; }
        public string Stage { get; set; }
        public string StageEN { get; set; }
        public string Code { get; set; }
        public string ParentCode { get; set; }
    }
}
