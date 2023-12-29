using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class ClearanceValue
{
    public int Id { get; set; }

    public int? FormId { get; set; }

    public int? AccId { get; set; }

    public int? TurnOver { get; set; }

    public int? Paid { get; set; }

    public int? NotApplicable { get; set; }

    public decimal? ForDeduction { get; set; }

    public decimal? ForAddition { get; set; }

    public string? Remarks { get; set; }

    public int? Deactivated { get; set; }

    public long? RemainingBalance { get; set; }

    public int? PasswordReset { get; set; }

    public string? EmployeeNumber { get; set; }

    public string? TrackingNumber { get; set; }

    public bool? IsExternalResponse { get; set; }
}
