using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class Announcement
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public string? BannerPath { get; set; }

    public string? AnnouncementContent { get; set; }

    public int? IsPreview { get; set; }

    public int? IsActive { get; set; }

    public int? IsPosted { get; set; }
}
