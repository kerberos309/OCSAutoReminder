using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class UserCoverage
{
    public int Id { get; set; }

    public int UserProfileId { get; set; }

    public int ApplicationId { get; set; }

    public int BusinessUnitId { get; set; }

    public int? DivisionId { get; set; }

    public int RoleId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual BusinessUnit BusinessUnit { get; set; } = null!;

    public virtual Division? Division { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual UserProfile UserProfile { get; set; } = null!;
}
