using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class AppUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ApplicationId { get; set; }

    public int NumberVisit { get; set; }

    public DateTime DateCreated { get; set; }

    public string CreatedBy { get; set; } = null!;

    public virtual Application Application { get; set; } = null!;

    public virtual UserProfile User { get; set; } = null!;
}
