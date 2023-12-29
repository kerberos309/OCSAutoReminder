using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MaintenanceEmploymentStatus
{
    public int Id { get; set; }

    public string? EmploymentStatus { get; set; }

    public string? StatusCode { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }
}
