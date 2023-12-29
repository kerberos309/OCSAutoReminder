namespace Domain.Entities.EAMS
{
    public class UserDefaultScheduleEntity
    {
        public int Id { get; set; }

        public bool? IsWeekly { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public Guid? EmployeeCode { get; set; }

        public bool? Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public string? Code { get; set; }

        public string? WeeklyScheduleCode { get; set; }

        public virtual UserProfileEntity? EmployeeCodeNavigation { get; set; }

        public virtual WeeklyScheduleEntity? WeeklyScheduleCodeNavigation { get; set; }
    }
}