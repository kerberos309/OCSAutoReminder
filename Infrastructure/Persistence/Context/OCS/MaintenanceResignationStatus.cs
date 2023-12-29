using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MaintenanceResignationStatus
{
    public int Id { get; set; }

    public string? StatusCode { get; set; }

    public string? StatusName { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool? IsActive { get; set; }
}
