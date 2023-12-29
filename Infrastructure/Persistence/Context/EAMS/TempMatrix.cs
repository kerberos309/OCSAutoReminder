using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class TempMatrix
{
    public int Id { get; set; }

    public string EmployeeNumber { get; set; } = null!;

    public string? EmployeeCode { get; set; }

    public string WeeklyScheduleCode { get; set; } = null!;

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int ForEdit { get; set; }

    public string Status { get; set; } = null!;
}
