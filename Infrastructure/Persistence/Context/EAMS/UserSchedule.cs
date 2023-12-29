using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class UserSchedule
{
    public int Id { get; set; }

    public Guid EmployeeCode { get; set; }

    public DateOnly DateFrom { get; set; }

    public DateOnly DateTo { get; set; }

    public string? Remarks { get; set; }

    public string? Status { get; set; }

    public bool Archived { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool? EmailSent { get; set; }

    public virtual UserProfile EmployeeCodeNavigation { get; set; } = null!;

    public virtual ICollection<UserScheduleDetail> UserScheduleDetails { get; set; } = new List<UserScheduleDetail>();
}
