﻿using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class Company
{
    public int Id { get; set; }

    public int BusinessUnitId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual BusinessUnit BusinessUnit { get; set; } = null!;

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
}
