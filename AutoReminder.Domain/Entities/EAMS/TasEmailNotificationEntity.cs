namespace Domain.Entities.EAMS
{
    public class TasEmailNotificationEntity
    {
        public int Id { get; set; }

        public string Approvers { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Guid EmployeeCode { get; set; }

        public string? Status { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool? Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public virtual UserProfileEntity EmployeeCodeNavigation { get; set; } = null!;
    }
}