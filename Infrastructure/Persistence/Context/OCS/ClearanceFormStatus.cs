using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class ClearanceFormStatus
{
    public int Id { get; set; }

    public string? FormStatus { get; set; }

    public int? FormId { get; set; }

    public string? EmployeeNumber { get; set; }

    public string? TrackingNumber { get; set; }

    public int? BuValue { get; set; }

    public string? DepartmentValue { get; set; }

    public int? JoblevelValue { get; set; }

    public int? PositionValue { get; set; }

    public int? StatusValue { get; set; }

    public string? ForwardBy { get; set; }

    public string? ForwardTo { get; set; }

    public DateTime? ForwardDate { get; set; }

    public int? EnableForward { get; set; }

    public DateTime? RevertDate { get; set; }

    public string? RevertReason { get; set; }

    public DateTime? LeadTimeDate { get; set; }

    public long? LeadTimeCount { get; set; }

    public DateTime? AutoApproveDate { get; set; }

    public long? AutoApproveCount { get; set; }

    public int? IsAutoApprove { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public int? Reminder { get; set; }
}
