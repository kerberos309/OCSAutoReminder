﻿using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class ClearanceTrail
{
    public int Id { get; set; }

    public string? EmployeeNumber { get; set; }

    public string? TrackingNumber { get; set; }

    public string? ClearanceStatus { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? FormId { get; set; }
}
