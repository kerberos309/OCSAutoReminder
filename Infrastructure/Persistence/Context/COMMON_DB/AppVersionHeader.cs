using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class AppVersionHeader
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public string AppVersion { get; set; } = null!;

    public int AppVersionId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual ICollection<AppVersionDetail> AppVersionDetails { get; set; } = new List<AppVersionDetail>();

    public virtual AppVersion AppVersionNavigation { get; set; } = null!;

    public virtual Application Application { get; set; } = null!;
}
