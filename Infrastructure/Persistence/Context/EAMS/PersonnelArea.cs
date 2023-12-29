using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class PersonnelArea
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateOnly? DateEdited { get; set; }

    public virtual ICollection<DailyWorkSchedulePersonnelArea> DailyWorkSchedulePersonnelAreas { get; set; } = new List<DailyWorkSchedulePersonnelArea>();

    public virtual ICollection<LeaveTypePersonnelArea> LeaveTypePersonnelAreas { get; set; } = new List<LeaveTypePersonnelArea>();

    public virtual ICollection<WeeklySchedule> WeeklySchedules { get; set; } = new List<WeeklySchedule>();
}
