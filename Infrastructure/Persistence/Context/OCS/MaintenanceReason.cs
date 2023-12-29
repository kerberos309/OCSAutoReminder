using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MaintenanceReason
{
    public int Id { get; set; }

    public string? FldReason { get; set; }

    public DateTime? FldDateCreated { get; set; }

    public bool? FldIsActive { get; set; }

    public bool? FldIsOthers { get; set; }

    public bool? FldIsDeleted { get; set; }
}
