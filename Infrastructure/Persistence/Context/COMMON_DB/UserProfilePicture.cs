using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class UserProfilePicture
{
    public int Id { get; set; }

    public int UserProfileId { get; set; }

    public byte[] ProfilePicture { get; set; } = null!;

    public bool? Active { get; set; }

    public string Type { get; set; } = null!;

    public virtual UserProfile UserProfile { get; set; } = null!;
}
