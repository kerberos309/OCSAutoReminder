using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class LeaveTypeRequirement
{
    public int Id { get; set; }

    public string LeaveTypeCode { get; set; } = null!;

    public string Requirements { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? DateEdited { get; set; }

    public string? EditedBy { get; set; }

    public bool Active { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual LeaveType LeaveTypeCodeNavigation { get; set; } = null!;
}
