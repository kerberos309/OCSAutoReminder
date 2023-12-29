using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class ExemptedEmployee
{
    public int Id { get; set; }

    public Guid EmployeeCode { get; set; }

    public string EmployeeNumber { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateOnly? DateEdited { get; set; }

    public bool? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateOnly? DateDeleted { get; set; }

    public virtual UserProfile EmployeeCodeNavigation { get; set; } = null!;
}
