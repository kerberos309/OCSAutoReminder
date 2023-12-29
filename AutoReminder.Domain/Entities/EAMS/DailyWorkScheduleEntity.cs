namespace Domain.Entities.EAMS
{
    public class DailyWorkScheduleEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string? TimeGroup { get; set; }

        public TimeOnly TimeStart { get; set; }

        public TimeOnly TimeEnd { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateOnly DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateOnly? DateEdited { get; set; }

        public bool? Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateOnly? DeletedDate { get; set; }

        public virtual ICollection<DailyWorkSchedulePersonnelAreaEntity> DailyWorkSchedulePersonnelAreas { get; set; } = new List<DailyWorkSchedulePersonnelAreaEntity>();

        public virtual ICollection<TasApplicationEntity> TasApplications { get; set; } = new List<TasApplicationEntity>();

        public virtual ICollection<UserScheduleDetailEntity> UserScheduleDetails { get; set; } = new List<UserScheduleDetailEntity>();

        public virtual ICollection<WeeklyScheduleDetailEntity> WeeklyScheduleDetails { get; set; } = new List<WeeklyScheduleDetailEntity>();
    }
}