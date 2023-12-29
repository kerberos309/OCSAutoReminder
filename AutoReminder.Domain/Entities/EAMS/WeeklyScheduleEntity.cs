namespace Domain.Entities.EAMS
{
    public class WeeklyScheduleEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateOnly DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateOnly? DateEdited { get; set; }

        public bool? Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateOnly? DateDeleted { get; set; }

        public string? PersonnelAreaCode { get; set; }

        public string Code { get; set; } = null!;

        public virtual PersonnelAreaEntity? PersonnelAreaCodeNavigation { get; set; }

        public virtual ICollection<UserDefaultScheduleEntity> UserDefaultSchedules { get; set; } = new List<UserDefaultScheduleEntity>();

        public virtual ICollection<WeeklyScheduleDetailEntity> WeeklyScheduleDetails { get; set; } = new List<WeeklyScheduleDetailEntity>();
    }
}