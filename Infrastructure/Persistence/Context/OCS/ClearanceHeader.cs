using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class ClearanceHeader
{
    public int Id { get; set; }

    public Guid? PkId { get; set; }

    public string? EmployeeNumber { get; set; }

    public string? TrackingNumber { get; set; }

    public DateTime? LastWorkDay { get; set; }

    public DateTime? ResignationEffectiveDate { get; set; }

    public string? ReleasedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ClearanceStatus { get; set; }

    public int? MatrixId { get; set; }

    public DateTime? DateEmail { get; set; }

    public DateTime? DateReceived { get; set; }

    public DateTime? DateCompleted { get; set; }

    public int? FaFlagging { get; set; }
}
