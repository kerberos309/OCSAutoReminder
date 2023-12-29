using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class ApproverDelegation
{
    public int Id { get; set; }

    public Guid EmployeeCode { get; set; }

    public string EmployeeNumber { get; set; } = null!;

    public Guid DelegatedEmployeeCode { get; set; }

    public bool Active { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool? EmailNotif { get; set; }

    public DateTime? DateEmailed { get; set; }

    public virtual UserProfile DelegatedEmployeeCodeNavigation { get; set; } = null!;

    public virtual UserProfile EmployeeCodeNavigation { get; set; } = null!;
}
