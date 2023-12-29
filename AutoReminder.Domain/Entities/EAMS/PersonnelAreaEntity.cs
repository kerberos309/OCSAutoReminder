namespace Domain.Entities.EAMS
{
    public class PersonnelAreaEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateOnly DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateOnly? DateEdited { get; set; }

        public virtual ICollection<DailyWorkSchedulePersonnelAreaEntity> DailyWorkSchedulePersonnelAreas { get; set; } = new List<DailyWorkSchedulePersonnelAreaEntity>();

        public virtual ICollection<LeaveTypePersonnelAreaEntity> LeaveTypePersonnelAreas { get; set; } = new List<LeaveTypePersonnelAreaEntity>();

        public virtual ICollection<WeeklyScheduleEntity> WeeklySchedules { get; set; } = new List<WeeklyScheduleEntity>();
    }
}