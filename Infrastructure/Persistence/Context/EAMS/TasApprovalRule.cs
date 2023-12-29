using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class TasApprovalRule
{
    public int Id { get; set; }

    public int BusinessUnitId { get; set; }

    public int TasTypeId { get; set; }

    public string? LeaveTypeCode { get; set; }

    public int ApprovalLevel { get; set; }

    public bool Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public virtual LeaveType? LeaveTypeCodeNavigation { get; set; }

    public virtual TasType TasType { get; set; } = null!;
}
