namespace Domain.Entities.EAMS
{
    public class UserDefineApproverEntity
    {
        public int Id { get; set; }

        public Guid EmployeeCode { get; set; }

        public Guid ApproverEmployeeCode { get; set; }

        public int ApprovalLevel { get; set; }

        public bool Active { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool? Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string? Status { get; set; }

        public virtual UserProfileEntity ApproverEmployeeCodeNavigation { get; set; } = null!;

        public virtual UserProfileEntity EmployeeCodeNavigation { get; set; } = null!;
    }
}