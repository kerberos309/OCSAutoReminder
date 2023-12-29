namespace Domain.Entities.EAMS
{
    public class TasApprovalEntity
    {
        public int Id { get; set; }

        public int TasApplicationId { get; set; }

        public Guid EmployeeCode { get; set; }

        public int ApprovalLevel { get; set; }

        public bool DelegatedApprover { get; set; }

        public int? ApproverDelegationId { get; set; }

        public string? Status { get; set; }

        public string? Reason { get; set; }

        public DateTime Date { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool? Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public virtual UserProfileEntity EmployeeCodeNavigation { get; set; } = null!;

        public virtual TasApplicationEntity TasApplication { get; set; } = null!;
    }
}