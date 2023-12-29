using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class WeeklySchedule
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateOnly? DateEdited { get; set; }

    public bool? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateOnly? DateDeleted { get; set; }

    public string? PersonnelAreaCode { get; set; }

    public string Code { get; set; } = null!;

    public virtual PersonnelArea? PersonnelAreaCodeNavigation { get; set; }

    public virtual ICollection<UserDefaultSchedule> UserDefaultSchedules { get; set; } = new List<UserDefaultSchedule>();

    public virtual ICollection<WeeklyScheduleDetail> WeeklyScheduleDetails { get; set; } = new List<WeeklyScheduleDetail>();
}
