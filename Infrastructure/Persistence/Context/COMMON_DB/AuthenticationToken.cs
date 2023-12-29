using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class AuthenticationToken
{
    public long Id { get; set; }

    public int UserProfileId { get; set; }

    public Guid AuthToken { get; set; }

    public DateTime DateIssued { get; set; }

    public DateTime DateExpiry { get; set; }

    public DateTime? DateExtended { get; set; }

    public string? ExtendedApps { get; set; }

    public virtual UserProfile UserProfile { get; set; } = null!;
}
