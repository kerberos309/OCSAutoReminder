﻿using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class DailyWorkSchedulePersonnelArea
{
    public int Id { get; set; }

    public string DailyWorkScheduleCode { get; set; } = null!;

    public string PersonnelAreaCode { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? DailyWorkScheduleId { get; set; }

    public virtual DailyWorkSchedule DailyWorkScheduleCodeNavigation { get; set; } = null!;

    public virtual PersonnelArea PersonnelAreaCodeNavigation { get; set; } = null!;
}
