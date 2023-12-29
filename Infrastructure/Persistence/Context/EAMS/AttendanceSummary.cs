using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class AttendanceSummary
{
    public int Id { get; set; }

    public Guid EmployeeCode { get; set; }

    public DateOnly DateFrom { get; set; }

    public DateOnly DateTo { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateOnly? DateEdited { get; set; }

    public string? Remarks { get; set; }

    public virtual ICollection<AttendanceSummaryStatus> AttendanceSummaryStatuses { get; set; } = new List<AttendanceSummaryStatus>();

    public virtual UserProfile EmployeeCodeNavigation { get; set; } = null!;
}
