using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Domain.Entities.Common;

namespace MatchwiseServer.Domain.Entities
{
    public class Interview : BaseEntity
    {
        public string? CandidateName { get; set; }
        public string? JobPosition { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string? Status { get; set; }
        public List<string>? Questions { get; set; }
        public List<string>? ChatMessages { get; set; }

    }
}
