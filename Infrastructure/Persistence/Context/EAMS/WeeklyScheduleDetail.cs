using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class WeeklyScheduleDetail
{
    public int Id { get; set; }

    public string DayName { get; set; } = null!;

    public string DwsCode { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateOnly? DateEdited { get; set; }

    public string WeeklyScheduleCode { get; set; } = null!;

    public virtual DailyWorkSchedule DwsCodeNavigation { get; set; } = null!;

    public virtual WeeklySchedule WeeklyScheduleCodeNavigation { get; set; } = null!;
}
