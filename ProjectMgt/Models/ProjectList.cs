using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMgt.Models
{
    public class ProjectList
    {
        [BsonId]
        public Guid id { get; set; }
        public string System { get; set; }
        public string ErrKind { get; set; }
        public string Desc { get; set; }
        public string Applicant { get; set; }
        public string PIC { get; set; }
        public string ReqFormNo { get; set; }
        public string ReqFormDesc { get; set; }
        public string Stage { get; set; }
        public string UserExpectedDate { get; set; }
        public string StageEstimateFinish { get; set; }
        public string StageActualFinish { get; set; }
        public string TestDateEstimate { get; set; }
        public string ApplyDate { get; set; }
        public string Memo { get; set; }
        public string FileName { get; set; }
        public string Week { get; set; }
        public string IsNormal { get; set; }
        public Guid IdWeek { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
