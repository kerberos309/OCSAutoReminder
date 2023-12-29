namespace Domain.Entities.EAMS
{
    public class AttendanceSummaryEntity
    {
        public int Id { get; set; }

        public Guid EmployeeCode { get; set; }

        public DateOnly DateFrom { get; set; }

        public DateOnly DateTo { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateOnly DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateOnly? DateEdited { get; set; }

        public string? Remarks { get; set; }

        public virtual ICollection<AttendanceSummaryStatusEntity> AttendanceSummaryStatuses { get; set; } = new List<AttendanceSummaryStatusEntity>();

        public virtual UserProfileEntity EmployeeCodeNavigation { get; set; } = null!;
    }
}