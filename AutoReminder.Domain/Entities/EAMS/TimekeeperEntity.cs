namespace Domain.Entities.EAMS
{
    public class TimekeeperEntity
    {
        public int Id { get; set; }

        public Guid EmployeeCode { get; set; }

        public int BusinessUnitId { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateOnly DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateOnly? DateEdited { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string? DeletedBy { get; set; }

        public virtual UserProfileEntity EmployeeCodeNavigation { get; set; } = null!;
    }
}