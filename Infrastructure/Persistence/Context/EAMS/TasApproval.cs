using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class TasApproval
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

    public virtual UserProfile EmployeeCodeNavigation { get; set; } = null!;

    public virtual TasApplication TasApplication { get; set; } = null!;
}
