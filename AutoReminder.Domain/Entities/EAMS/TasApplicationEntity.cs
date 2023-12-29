using System.Runtime.InteropServices.JavaScript;

namespace Domain.Entities.EAMS
{
    public class TasApplicationEntity
    {
        public int Id { get; set; }

        public Guid EmployeeCode { get; set; }

        public string EmployeeNumber { get; set; } = null!;

        public int TasTypeId { get; set; }

        public string LeaveTypeCode { get; set; } = null!;

        public DateOnly DateFrom { get; set; }

        public DateOnly DateTo { get; set; }

        public TimeOnly TimeStart { get; set; }

        public TimeOnly TimeEnd { get; set; }

        public string? Reason { get; set; }

        public string? Destination { get; set; }

        public string? LateSubmissionReason { get; set; }

        public string? CancelledReason { get; set; }

        public DateTime? CancelledDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool? Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string? ApplicationStatus { get; set; }

        public string? HalfdayType { get; set; }

        public string? DwsCode { get; set; }

        public string? SapPostingStatus { get; set; }

        public bool? FioPreviousDay { get; set; }

        public bool? FioInOut { get; set; }

        public virtual DailyWorkScheduleEntity? DwsCodeNavigation { get; set; }

        public virtual UserProfileEntity EmployeeCodeNavigation { get; set; } = null!;

        public virtual LeaveTypeEntity LeaveTypeCodeNavigation { get; set; } = null!;

        public virtual ICollection<TasApprovalEntity> TasApprovals { get; set; } = new List<TasApprovalEntity>();

        public virtual TasTypeEntity TasType { get; set; } = null!;
    }
}