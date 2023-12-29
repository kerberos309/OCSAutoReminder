namespace Domain.Entities.EAMS
{
    public class AttendanceSummaryStatusEntity
    {
        public int Id { get; set; }

        public int AttendanceSummaryId { get; set; }

        public Guid EmployeeCode { get; set; }

        public string Status { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateOnly DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateOnly? DateEdited { get; set; }

        public Guid? ApproverCode { get; set; }

        public virtual UserProfileEntity? ApproverCodeNavigation { get; set; }

        public virtual AttendanceSummaryEntity AttendanceSummary { get; set; } = null!;

        public virtual UserProfileEntity EmployeeCodeNavigation { get; set; } = null!;
    }
}