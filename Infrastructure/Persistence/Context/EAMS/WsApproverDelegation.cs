using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class WsApproverDelegation
{
    public int Id { get; set; }

    public Guid? EmployeeCode { get; set; }

    public string? EmployeeNumber { get; set; }

    public Guid? DelegatedEmployeeCode { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public string? DeletedBy { get; set; }

    public bool? Deleted { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool? EmailNotif { get; set; }

    public DateTime? DateEmailed { get; set; }
}
