namespace Domain.Entities.EAMS
{
    public class UserScheduleEntity
    {
        public int Id { get; set; }

        public Guid EmployeeCode { get; set; }

        public DateOnly DateFrom { get; set; }

        public DateOnly DateTo { get; set; }

        public string? Remarks { get; set; }

        public string? Status { get; set; }

        public bool Archived { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public bool? EmailSent { get; set; }

        public virtual UserProfileEntity EmployeeCodeNavigation { get; set; } = null!;

        public virtual ICollection<UserScheduleDetailEntity> UserScheduleDetails { get; set; } = new List<UserScheduleDetailEntity>();
    }
}