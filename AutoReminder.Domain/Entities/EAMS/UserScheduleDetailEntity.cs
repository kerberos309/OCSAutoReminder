namespace Domain.Entities.EAMS
{
    public class UserScheduleDetailEntity
    {
        public int Id { get; set; }

        public Guid Code { get; set; }

        public int UserScheduleId { get; set; }

        public DateOnly WorkScheduleDate { get; set; }

        public string DwsCode { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateOnly DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateOnly? DateEdited { get; set; }

        public Guid? EmployeeCode { get; set; }

        public string? DwsStatus { get; set; }

        public virtual DailyWorkScheduleEntity DwsCodeNavigation { get; set; } = null!;

        public virtual UserScheduleEntity UserSchedule { get; set; } = null!;
    }
}