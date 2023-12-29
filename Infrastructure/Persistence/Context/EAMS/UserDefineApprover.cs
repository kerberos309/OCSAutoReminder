using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class UserDefineApprover
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

    public virtual UserProfile ApproverEmployeeCodeNavigation { get; set; } = null!;

    public virtual UserProfile EmployeeCodeNavigation { get; set; } = null!;
}
