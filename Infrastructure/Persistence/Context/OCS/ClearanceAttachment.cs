using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class ClearanceAttachment
{
    public int Id { get; set; }

    public Guid? PkId { get; set; }

    public string? TrackingNumber { get; set; }

    public string? Comments { get; set; }

    public string? EmployeeNumber { get; set; }

    public string? EmployeeName { get; set; }

    public DateTime? DateCreated { get; set; }
}
