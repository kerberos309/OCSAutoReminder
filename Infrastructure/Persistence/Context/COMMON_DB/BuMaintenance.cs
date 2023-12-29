using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class BuMaintenance
{
    public int Id { get; set; }

    public int BuId { get; set; }

    public string BuCode { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? Version { get; set; }

    public string? DownloadUrl { get; set; }

    public bool IsSupported { get; set; }

    public bool IsAndroid { get; set; }

    public bool IsIos { get; set; }

    public bool ForceUpdate { get; set; }

    public bool WithStore { get; set; }

    public bool BySchedule { get; set; }

    public bool Enable { get; set; }

    public DateTime? DatetimeFrom { get; set; }

    public DateTime? DatetimeTo { get; set; }

    public DateOnly DateCreated { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateOnly? DateEdited { get; set; }

    public string? EditedBy { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateOnly? DateDeleted { get; set; }

    public virtual ICollection<BuMaintenanceStore> BuMaintenanceStores { get; set; } = new List<BuMaintenanceStore>();
}
