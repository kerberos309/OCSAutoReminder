using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class RoleModule
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int ApplicationId { get; set; }

    public int ModuleId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
