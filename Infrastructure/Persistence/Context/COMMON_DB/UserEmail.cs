using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class UserEmail
{
    public int Id { get; set; }

    public int UserProfileId { get; set; }

    public string EmailAddress { get; set; } = null!;

    public bool Primary { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual UserProfile UserProfile { get; set; } = null!;
}
