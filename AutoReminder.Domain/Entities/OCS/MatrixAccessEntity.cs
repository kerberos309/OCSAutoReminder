using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MatrixAccessEntity
    {
        public int Id { get; set; }
        public int? MatrixId { get; set; }
        public int? EntityId { get; set; }
        public int FormId { get; set; }
        public string? IdName { get; set; }
        public string? IdValue { get; set; }
        public int? ProcessingLeadTime { get; set; }
        public int? AutoApprove { get; set; }
        public int? AutoApproval { get; set; }
        public int? ReminderLeadTime { get; set; }
        public int? AutoRelease { get; set; }
        public int? AutoReleasedLeadTime { get; set; }
        public int? AutoNotification { get; set; }
        public int? EmailOption { get; set; }
        public int? InOrder { get; set; }
    }
}
