using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class ClearanceFormStatusEntity
    {
        public int Id { get; set; }
        public string? FormStatus { get; set; }
        public int? FormId { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? TrackingNumber { get; set; }
        public int? BuValue { get; set; }
        public string? DepartmentValue { get; set; }
        public int? JobLevelValue { get; set; }
        public int? PositionValue { get; set; }
        public int? StatusValue { get; set; }
        public string? ForwardBy { get; set; }
        public string? ForwardTo { get; set; }
        public DateTime? ForwardDate { get; set; }
        public bool EnableForward { get; set; }
        public DateTime? RevertDate { get; set; }
        public string? RevertReason { get; set; }
        public DateTime? LeadTimeDate { get; set; }
        public int? LeadTimeCount { get; set; }
        public DateTime? AutoApproveDate { get; set; }
        public int? AutoApproveCount { get; set; }
        public bool IsAutoApprove { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Reminder { get; set; }
    }
}
