using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class AttendanceSummaryStatus
{
    public int Id { get; set; }

    public int AttendanceSummaryId { get; set; }

    public Guid EmployeeCode { get; set; }

    public string Status { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateOnly? DateEdited { get; set; }

    public Guid? ApproverCode { get; set; }

    public virtual UserProfile? ApproverCodeNavigation { get; set; }

    public virtual AttendanceSummary AttendanceSummary { get; set; } = null!;

    public virtual UserProfile EmployeeCodeNavigation { get; set; } = null!;
}
