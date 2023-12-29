namespace Domain.Entities.EAMS
{
    public class DtrRawEntity
    {
        public int Id { get; set; }

        public Guid EmployeeCode { get; set; }

        public string AccessNumber { get; set; } = null!;

        public DateOnly DtrDate { get; set; }

        public TimeOnly DtrTime { get; set; }

        public string? LogFile { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual UserProfileEntity EmployeeCodeNavigation { get; set; } = null!;
    }
}