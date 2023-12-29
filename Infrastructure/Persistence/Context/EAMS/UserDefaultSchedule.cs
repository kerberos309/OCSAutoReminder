using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class UserDefaultSchedule
{
    public int Id { get; set; }

    public bool? IsWeekly { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public Guid? EmployeeCode { get; set; }

    public bool? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    public string? Code { get; set; }

    public string? WeeklyScheduleCode { get; set; }

    public virtual UserProfile? EmployeeCodeNavigation { get; set; }

    public virtual WeeklySchedule? WeeklyScheduleCodeNavigation { get; set; }
}
