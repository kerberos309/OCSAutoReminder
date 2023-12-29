﻿using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class Role
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public string Name { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual ICollection<RoleModule> RoleModules { get; set; } = new List<RoleModule>();

    public virtual ICollection<UserCoverage> UserCoverages { get; set; } = new List<UserCoverage>();
}
