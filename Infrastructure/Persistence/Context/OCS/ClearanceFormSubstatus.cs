using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class ClearanceFormSubstatus
{
    public int Id { get; set; }

    public string? FormStatus { get; set; }

    public int? FormId { get; set; }

    public string? EmployeeNumber { get; set; }

    public string? TrackingNumber { get; set; }

    public string? DepartmentValue { get; set; }

    public string? ForwardBy { get; set; }

    public string? ForwardTo { get; set; }

    public DateTime? ForwardDate { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string? HoldBy { get; set; }

    public DateTime? HoldDate { get; set; }
}
