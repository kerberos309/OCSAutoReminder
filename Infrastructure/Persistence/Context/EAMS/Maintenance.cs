using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class Maintenance
{
    public int Id { get; set; }

    public bool IsMaintenance { get; set; }

    public string? Version { get; set; }

    public bool IsSupported { get; set; }

    public string? DownloadUrl { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool IsAndroid { get; set; }

    public bool ForceUpdate { get; set; }
}
