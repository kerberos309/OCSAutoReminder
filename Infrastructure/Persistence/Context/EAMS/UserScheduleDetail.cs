using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class UserScheduleDetail
{
    public int Id { get; set; }

    public Guid Code { get; set; }

    public int UserScheduleId { get; set; }

    public DateOnly WorkScheduleDate { get; set; }

    public string DwsCode { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateOnly? DateEdited { get; set; }

    public Guid? EmployeeCode { get; set; }

    public string? DwsStatus { get; set; }

    public virtual DailyWorkSchedule DwsCodeNavigation { get; set; } = null!;

    public virtual UserSchedule UserSchedule { get; set; } = null!;
}
