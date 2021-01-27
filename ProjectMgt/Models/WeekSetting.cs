using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMgt.Models
{
    public class WeekSetting
    {
        [BsonId]
        public Guid id { get; set; }
        public string Week { get; set; }
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isUpload { get; set; }
    }
}
