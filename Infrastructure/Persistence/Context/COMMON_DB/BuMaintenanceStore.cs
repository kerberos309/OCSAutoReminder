using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class BuMaintenanceStore
{
    public int Id { get; set; }

    public int? BuMaintenanceId { get; set; }

    public int? StoreId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? Message { get; set; }

    public string? Title { get; set; }

    public virtual BuMaintenance? BuMaintenance { get; set; }
}
