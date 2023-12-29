using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class DailyWorkScheduleTest
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? TimeGroup { get; set; }

    public TimeOnly TimeStart { get; set; }

    public TimeOnly TimeEnd { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateOnly? DateEdited { get; set; }

    public bool? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateOnly? DeletedDate { get; set; }

    public string? PersonnelAreaCode { get; set; }
}
