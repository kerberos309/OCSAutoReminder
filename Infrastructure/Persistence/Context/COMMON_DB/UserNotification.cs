using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class UserNotification
{
    public int Id { get; set; }

    public int UserProfileId { get; set; }

    public string? Title { get; set; }

    public string Message { get; set; } = null!;

    public int ApplicationId { get; set; }

    public string? RedirectUrl { get; set; }

    public bool ReadStatus { get; set; }

    public string? Remarks { get; set; }

    public int? Priority { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public int? ReferenceId { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual UserProfile UserProfile { get; set; } = null!;
}
