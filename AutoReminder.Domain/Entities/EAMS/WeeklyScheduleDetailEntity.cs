namespace Domain.Entities.EAMS
{
    public class WeeklyScheduleDetailEntity
    {
        public int Id { get; set; }

        public string DayName { get; set; } = null!;

        public string DwsCode { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateOnly DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateOnly? DateEdited { get; set; }

        public string WeeklyScheduleCode { get; set; } = null!;

        public virtual DailyWorkScheduleEntity DwsCodeNavigation { get; set; } = null!;

        public virtual WeeklyScheduleEntity WeeklyScheduleCodeNavigation { get; set; } = null!;
    }
}